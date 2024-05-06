using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoListApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<ToDoItem> items;
        public ObservableCollection<ToDoItem> Items
        {
            get => items;
            set
            {
                if (items != value)
                {
                    items = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainViewModel()
        {
            Items = new ObservableCollection<ToDoItem>();
        }

        public void AddTodoItem(string task, string category, int priority)
        {
            if (!string.IsNullOrWhiteSpace(task))
            {
                var newItem = new ToDoItem
                {
                    Task = task,
                    Category = category,
                    Priority = priority,
                    IsCompleted = false
                };
                Items.Add(newItem);
                OnPropertyChanged(nameof(Items));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
