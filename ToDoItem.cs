using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ToDoListApp;

public class ToDoItem : INotifyPropertyChanged
{
    private string task;
    private bool isCompleted;
    private string category;
    private int priority;

    public event PropertyChangedEventHandler PropertyChanged;

    public string Task
    {
        get => task;
        set
        {
            if (task != value)
            {
                task = value;
                OnPropertyChanged();
            }
        }
    }

    public bool IsCompleted
    {
        get => isCompleted;
        set
        {
            if (isCompleted != value)
            {
                isCompleted = value;
                OnPropertyChanged();
            }
        }
    }

    public string Category
    {
        get => category;
        set
        {
            if (category != value)
            {
                category = value;
                OnPropertyChanged();
            }
        }
    }

    public int Priority
    {
        get => priority;
        set
        {
            if (priority != value)
            {
                priority = value;
                OnPropertyChanged();
            }
        }
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
