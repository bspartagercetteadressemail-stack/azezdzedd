using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using ValorantPorting.ViewModels;

namespace ValorantPorting.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();

        // Make title bar draggable
        var titleBar = this.FindControl<Border>("TitleBar");
        if (titleBar == null)
        {
            // Use the entire first row as draggable area
            PointerPressed += (sender, e) =>
            {
                if (e.GetCurrentPoint(this).Position.Y < 40)
                {
                    BeginMoveDrag(e);
                }
            };
        }
    }

    private void MinimizeWindow(object? sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void MaximizeWindow(object? sender, RoutedEventArgs e)
    {
        WindowState = WindowState == WindowState.Maximized
            ? WindowState.Normal
            : WindowState.Maximized;
    }

    private void CloseWindow(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}
