using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ToDo
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            ToDoItems = new ObservableCollection<string>();
        }

        private string _toDoText;
        public string ToDoText
        {
            get { return _toDoText; }
            set
            {
                if(_toDoText != value)
                {
                    _toDoText = value;
                    RaisePropertyChanged("ToDoText");
                }
            }
        }

        private ObservableCollection<string> _toDoItems;
        public ObservableCollection<String> ToDoItems
        {
            get { return _toDoItems; }
            set
            {
                if (_toDoItems != value)
                {
                    _toDoItems = value;
                    RaisePropertyChanged("ToDoItems");
                }
            }
        }

        public void AddToDoItem()
        {
            ToDoItems.Add(ToDoText);
            ToDoText = "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChangedEventArgs args = 
                    new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, args);
            }
        }
    }
}
