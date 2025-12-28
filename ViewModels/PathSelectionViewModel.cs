using System;
using System.Reactive;
using ReactiveUI;

namespace ValorantPorting.ViewModels;

/// <summary>
/// View model for path selection screen
/// </summary>
public class PathSelectionViewModel : ViewModelBase
{
    public event Action<string>? PathSelected;

    public ReactiveCommand<Unit, Unit> BrowseCommand { get; }

    public PathSelectionViewModel()
    {
        BrowseCommand = ReactiveCommand.Create(Browse);
    }

    private void Browse()
    {
        // This will be handled in the view code-behind with platform-specific folder picker
    }

    public void RaisePathSelected(string path)
    {
        PathSelected?.Invoke(path);
    }
}
