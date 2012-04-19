using System.Windows;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Input;

namespace Cars
{
    public partial class CarDisplay : Window
    {
        public CarDisplay()
        {
            InitializeComponent();
            _repository = new CarRepository("cars.csv");
            _carsView.ItemsSource = _repository.FindAll();
        }

        private CarRepository _repository;

        private void _showAllButton_Click(object sender, RoutedEventArgs e)
        {
            _carsView.ItemsSource = _repository.FindAll();
        }

        private void _wostMileageButton_Click(object sender, RoutedEventArgs e)
        {
            _carsView.ItemsSource = _repository.FindWorstMpg().Take(50);
        }

        private void _bestMileageButton_Click(object sender, 
                                              RoutedEventArgs e)
        {
            _carsView.ItemsSource = _repository.FindBestMpg().Take(50);
        }

        private void _exportButton_Click(object sender, 
                                         RoutedEventArgs e)
        {
            _repository.Export("cars.xml");
        }

        private void _filter_Click(object sender, 
                                   RoutedEventArgs e)
        {               
            _carsView.ItemsSource = 
                _repository.Find(c => c.CityMPG > c.HighwayMPG);
        }

        private void _carsView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var result = from c in _repository.FindAll()
                         group c by c.Manufacturer into gc
                         orderby gc.Count() descending
                         select new
                         {
                             Manufacturer = gc.Key,
                             TotalCars = gc.Count(),
                             AvgCityMPG = gc.Average(c => c.CityMPG).ToString("N2"),
                             AvgHighwayMPG = gc.Average(c => c.HighwayMPG).ToString("N2")
                         };

            SummaryWindow summaryWindow = new SummaryWindow();
            summaryWindow.DataContext = result;
            summaryWindow.ShowDialog();
        }        
    }
}
