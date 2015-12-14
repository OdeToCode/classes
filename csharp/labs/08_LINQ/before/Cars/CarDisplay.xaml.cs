using System.Windows;
using System.Linq;
using System.Collections.Generic;

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
    }
}
