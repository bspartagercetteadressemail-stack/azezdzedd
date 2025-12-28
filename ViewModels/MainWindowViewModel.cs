using System;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using ValorantPorting.Services;

namespace ValorantPorting.ViewModels;

/// <summary>
/// Main window view model managing application state
/// </summary>
public class MainWindowViewModel : ViewModelBase
{
    private readonly ConfigService _configService;
    private readonly CUE4ParseService _cue4ParseService;
    private readonly ValorantApiService _apiService;

    private bool _showPathSelection = true;
    private bool _showLoading;
    private bool _showSuccess;
    private bool _showMainContent;
    private string _selectedPath = string.Empty;

    public MainWindowViewModel()
    {
        _configService = new ConfigService();
        _cue4ParseService = new CUE4ParseService();
        _apiService = new ValorantApiService();

        PathSelectionViewModel = new PathSelectionViewModel();
        LoadingViewModel = new LoadingViewModel();
        SuccessViewModel = new SuccessViewModel();
        MainContentViewModel = new MainContentViewModel(_apiService, _cue4ParseService, _configService);

        SelectPathCommand = ReactiveCommand.CreateFromTask<string>(SelectPathAsync);
        ContinueCommand = ReactiveCommand.Create(Continue);

        // Subscribe to PathSelectionViewModel
        PathSelectionViewModel.PathSelected += OnPathSelected;
        SuccessViewModel.ContinueRequested += OnContinueRequested;
    }

    public PathSelectionViewModel PathSelectionViewModel { get; }
    public LoadingViewModel LoadingViewModel { get; }
    public SuccessViewModel SuccessViewModel { get; }
    public MainContentViewModel MainContentViewModel { get; }

    public ReactiveCommand<string, Unit> SelectPathCommand { get; }
    public ReactiveCommand<Unit, Unit> ContinueCommand { get; }

    public bool ShowPathSelection
    {
        get => _showPathSelection;
        set => this.RaiseAndSetIfChanged(ref _showPathSelection, value);
    }

    public bool ShowLoading
    {
        get => _showLoading;
        set => this.RaiseAndSetIfChanged(ref _showLoading, value);
    }

    public bool ShowSuccess
    {
        get => _showSuccess;
        set => this.RaiseAndSetIfChanged(ref _showSuccess, value);
    }

    public bool ShowMainContent
    {
        get => _showMainContent;
        set => this.RaiseAndSetIfChanged(ref _showMainContent, value);
    }

    private async void OnPathSelected(string path)
    {
        await SelectPathAsync(path);
    }

    private async Task SelectPathAsync(string path)
    {
        try
        {
            _selectedPath = path;

            // Transition to loading
            ShowPathSelection = false;
            ShowLoading = true;

            LoadingViewModel.StatusMessage = "Validating Valorant installation...";
            await Task.Delay(800);

            // Initialize CUE4Parse
            LoadingViewModel.StatusMessage = "Initializing CUE4Parse...";
            var initialized = await _cue4ParseService.InitializeAsync(path);

            if (!initialized)
            {
                LoadingViewModel.StatusMessage = "Failed to initialize. Invalid path.";
                await Task.Delay(2000);

                // Return to path selection
                ShowLoading = false;
                ShowPathSelection = true;
                return;
            }

            LoadingViewModel.StatusMessage = "Loading assets...";
            await Task.Delay(1000);

            // Get asset count
            var assetCount = await _cue4ParseService.GetAssetCountAsync();
            SuccessViewModel.AssetCount = assetCount;

            // Save configuration
            await _configService.UpdateConfigAsync(config =>
            {
                config.ValorantPath = path;
            });

            LoadingViewModel.StatusMessage = "Initialization complete!";
            await Task.Delay(500);

            // Transition to success
            ShowLoading = false;
            ShowSuccess = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error selecting path: {ex.Message}");
            LoadingViewModel.StatusMessage = $"Error: {ex.Message}";
            await Task.Delay(2000);

            ShowLoading = false;
            ShowPathSelection = true;
        }
    }

    private void OnContinueRequested()
    {
        Continue();
    }

    private void Continue()
    {
        ShowSuccess = false;
        ShowMainContent = true;

        // Load initial data
        _ = MainContentViewModel.LoadDataAsync();
    }
}
