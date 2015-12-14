using System.Windows;

namespace ToDo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _model;
            AddButton.Click += new RoutedEventHandler(AddButton_Click);
        }

        void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _model.AddToDoItem();
        }

        MainWindowViewModel _model = new MainWindowViewModel();
    }   
}
