using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using ValorantPorting.Models;
using ValorantPorting.Services;

namespace ValorantPorting.ViewModels;

/// <summary>
/// View model for main content area with skin grid
/// </summary>
public class MainContentViewModel : ViewModelBase
{
    private readonly ValorantApiService _apiService;
    private readonly CUE4ParseService _cue4ParseService;
    private readonly ConfigService _configService;
    private readonly ExportService _exportService;

    private string _searchText = string.Empty;
    private bool _isLoading;
    private string _selectedView = "Grid";
    private List<WeaponSkin> _allSkins = new();

    public MainContentViewModel(
        ValorantApiService apiService,
        CUE4ParseService cue4ParseService,
        ConfigService configService)
    {
        _apiService = apiService;
        _cue4ParseService = cue4ParseService;
        _configService = configService;
        _exportService = new ExportService(_apiService, _cue4ParseService);

        Skins = new ObservableCollection<WeaponSkin>();

        SearchCommand = ReactiveCommand.Create<string>(Search);
        ExportCommand = ReactiveCommand.CreateFromTask(ExportToBlenderAsync);
        RefreshCommand = ReactiveCommand.CreateFromTask(LoadDataAsync);
    }

    public ObservableCollection<WeaponSkin> Skins { get; }

    public ReactiveCommand<string, Unit> SearchCommand { get; }
    public ReactiveCommand<Unit, Unit> ExportCommand { get; }
    public ReactiveCommand<Unit, Unit> RefreshCommand { get; }

    public string SearchText
    {
        get => _searchText;
        set
        {
            this.RaiseAndSetIfChanged(ref _searchText, value);
            Search(value);
        }
    }

    public bool IsLoading
    {
        get => _isLoading;
        set => this.RaiseAndSetIfChanged(ref _isLoading, value);
    }

    public string SelectedView
    {
        get => _selectedView;
        set => this.RaiseAndSetIfChanged(ref _selectedView, value);
    }

    public async Task LoadDataAsync()
    {
        try
        {
            IsLoading = true;

            var skins = await _apiService.GetWeaponSkinsAsync();
            _allSkins = skins;

            Skins.Clear();
            foreach (var skin in skins)
            {
                Skins.Add(skin);
            }

            IsLoading = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading data: {ex.Message}");
            IsLoading = false;
        }
    }

    private void Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            Skins.Clear();
            foreach (var skin in _allSkins)
            {
                Skins.Add(skin);
            }
            return;
        }

        var filtered = _allSkins
            .Where(s => s.DisplayName.Contains(query, StringComparison.OrdinalIgnoreCase))
            .ToList();

        Skins.Clear();
        foreach (var skin in filtered)
        {
            Skins.Add(skin);
        }
    }

    private async Task ExportToBlenderAsync()
    {
        try
        {
            var selectedSkins = Skins.Where(s => s.IsSelected).ToList();

            if (!selectedSkins.Any())
            {
                Console.WriteLine("No skins selected for export");
                return;
            }

            var config = await _configService.LoadConfigAsync();
            var outputPath = config.LastExportPath;

            if (string.IsNullOrEmpty(outputPath))
            {
                outputPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }

            Console.WriteLine($"Exporting {selectedSkins.Count} skins...");

            var result = await _exportService.BatchExportAsync(selectedSkins, outputPath);

            Console.WriteLine($"Export complete: {result.SuccessCount} succeeded, {result.FailedCount} failed");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during export: {ex.Message}");
        }
    }
}
