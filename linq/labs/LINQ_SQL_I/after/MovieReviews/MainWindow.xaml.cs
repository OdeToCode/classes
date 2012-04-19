using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MovieReviews.Model;

namespace MovieReviews
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            _mainWindow.DataContext = FetchMovies();
        }

        IQueryable<Movie> FetchMovies()
        {
            MovieDB db = new MovieDB();
            db.Log = Console.Out;
            return db.Movies;
        }

        void AlphabeticalClick(object sender,
                             RoutedEventArgs e)
        {            
            _mainWindow.DataContext = 
                FetchMovies().OrderBy(m => m.Title);
        }

        void ReleaseDateClick(object sender,
                              RoutedEventArgs e)
        {
            var query = FetchMovies().OrderBy(m => m.ReleaseDate);
            _mainWindow.DataContext = query;
                
        }

    }
}
