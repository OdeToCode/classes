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
            Car fakeCar = new Car()
                              {
                                  Manufacturer = "Pluralsight",
                                  Name = "Pluralsight Party Van",
                                  Displacement = 4,
                                  Cylinders = 8,
                                  Transmission = "R",
                                  CityMPG = 100,                                  
                                  HighwayMPG = 150
                              };

            IEnumerable<Car> cars = _repository.FindBestMpg().ToList();
            _repository.Add(fakeCar);
            cars = cars.Take(50);
            _carsView.ItemsSource = cars;

        }

        private void _exportButton_Click(object sender, 
                                         RoutedEventArgs e)
        {
            _repository.Export("cars.xml");
        }        
    }
}
