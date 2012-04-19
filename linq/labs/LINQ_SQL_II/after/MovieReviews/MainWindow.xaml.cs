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
using System.Collections.ObjectModel;

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
            _db = new MovieDB();
            _db.Log = Console.Out;
            return _db.Movies;
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

        private void DeleteButton_Click(object sender, 
                                        RoutedEventArgs e)
        {
            Review selectedReview = _reviewsList.SelectedItem 
                                    as Review;         
            _db.Reviews.DeleteOnSubmit(selectedReview);
            _db.SubmitChanges();

            ObservableCollection<Review> collection = 
                _reviewsList.ItemsSource as ObservableCollection<Review>;
            collection.Remove(selectedReview);
        }

        private void MovieSelection_Changed(
                        object sender, 
                        SelectionChangedEventArgs e)
        {
            Movie selectedMovie = _moviesList.SelectedItem as Movie;
            var reviews = new ObservableCollection<Review>(
                    selectedMovie.Reviews.ToList());
            _reviewsList.ItemsSource = reviews;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Review selectedReivew = _reviewsList.SelectedItem
                                    as Review;
            Review tempReview = new Review
            {
                Body = selectedReivew.Body,
                Rating = selectedReivew.Rating,
                Reviewer = selectedReivew.Reviewer,
                Summary = selectedReivew.Summary
            };
            EditWindow window = new EditWindow();
            window.DataContext = tempReview;
            if (window.ShowDialog() == true)
            {
                selectedReivew.Body = tempReview.Body;
                selectedReivew.Rating = tempReview.Rating;
                selectedReivew.Reviewer = tempReview.Reviewer;
                selectedReivew.Summary = tempReview.Summary;
                _db.SubmitChanges();
            }            
        }

        MovieDB _db;

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            Review newReview = new Review();
            EditWindow window = new EditWindow();
            window.DataContext = newReview;
            if (window.ShowDialog() == true)
            {
                Movie selectedMovie = _moviesList.SelectedItem
                                      as Movie;
                newReview.Movie = selectedMovie;

                _db.Reviews.InsertOnSubmit(newReview);
                _db.SubmitChanges();
                ((IList<Review>)_reviewsList.ItemsSource).Add(newReview);
            }
        }
    }
}
