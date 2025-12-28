using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using ValorantPorting.ViewModels;

namespace ValorantPorting.Views;

public partial class PathSelectionView : UserControl
{
    public PathSelectionView()
    {
        InitializeComponent();
    }

    private async void BrowseFolder(object? sender, RoutedEventArgs e)
    {
        try
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel == null) return;

            var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
            {
                Title = "Select Valorant Installation Folder",
                AllowMultiple = false
            });

            if (folders.Count > 0)
            {
                var selectedPath = folders[0].Path.LocalPath;

                if (DataContext is PathSelectionViewModel viewModel)
                {
                    viewModel.RaisePathSelected(selectedPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error selecting folder: {ex.Message}");
        }
    }
}
