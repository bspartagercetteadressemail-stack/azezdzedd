using Avalonia.Controls;
using Avalonia.Interactivity;
using ValorantPorting.Models;

namespace ValorantPorting.Views;

public partial class MainContentView : UserControl
{
    public MainContentView()
    {
        InitializeComponent();
    }

    private void SkinCard_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is WeaponSkin skin)
        {
            skin.IsSelected = !skin.IsSelected;

            // Visual feedback could be added here
            // For now, just log the selection
            System.Console.WriteLine($"Skin {skin.DisplayName} selected: {skin.IsSelected}");
        }
    }
}
