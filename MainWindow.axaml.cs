using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ToDoListApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);
            DataContext = new MainViewModel();
        }

        private void OnAddTaskClicked(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as MainViewModel;
            if (viewModel != null)
            {
                var description = this.FindControl<TextBox>("TaskDescription").Text;
                var categoryControl = this.FindControl<ComboBox>("TaskCategory").SelectedItem as ComboBoxItem;
                var category = categoryControl != null ? categoryControl.Content.ToString() : string.Empty;
                var priorityText = this.FindControl<TextBox>("TaskPriority").Text;
                int.TryParse(priorityText, out int priority); // 우선순위를 안전하게 변환

                if (!string.IsNullOrWhiteSpace(description))
                {
                    viewModel.AddTodoItem(description, category, priority);

                    // 입력 필드 초기화
                    this.FindControl<TextBox>("TaskDescription").Text = string.Empty;
                    this.FindControl<ComboBox>("TaskCategory").SelectedIndex = -1;
                    this.FindControl<TextBox>("TaskPriority").Text = string.Empty;
                }
            }
        }
    }
}