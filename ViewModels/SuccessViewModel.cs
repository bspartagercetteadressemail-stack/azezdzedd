using System;
using System.Reactive;
using ReactiveUI;

namespace ValorantPorting.ViewModels;

/// <summary>
/// View model for success screen
/// </summary>
public class SuccessViewModel : ViewModelBase
{
    private int _assetCount;

    public event Action? ContinueRequested;

    public ReactiveCommand<Unit, Unit> ContinueCommand { get; }

    public SuccessViewModel()
    {
        ContinueCommand = ReactiveCommand.Create(Continue);
    }

    public int AssetCount
    {
        get => _assetCount;
        set => this.RaiseAndSetIfChanged(ref _assetCount, value);
    }

    private void Continue()
    {
        ContinueRequested?.Invoke();
    }
}
