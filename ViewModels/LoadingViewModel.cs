using ReactiveUI;

namespace ValorantPorting.ViewModels;

/// <summary>
/// View model for loading screen
/// </summary>
public class LoadingViewModel : ViewModelBase
{
    private string _statusMessage = "Loading...";

    public string StatusMessage
    {
        get => _statusMessage;
        set => this.RaiseAndSetIfChanged(ref _statusMessage, value);
    }
}
