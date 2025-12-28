using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ValorantPorting.Models;

namespace ValorantPorting.Services;

/// <summary>
/// Service for managing application configuration
/// </summary>
public class ConfigService
{
    private static readonly string ConfigDirectory = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "ValorantPorting"
    );

    private static readonly string ConfigFilePath = Path.Combine(ConfigDirectory, "config.json");

    /// <summary>
    /// Loads configuration from disk or creates default
    /// </summary>
    public async Task<AppConfig> LoadConfigAsync()
    {
        try
        {
            if (!Directory.Exists(ConfigDirectory))
            {
                Directory.CreateDirectory(ConfigDirectory);
            }

            if (File.Exists(ConfigFilePath))
            {
                var json = await File.ReadAllTextAsync(ConfigFilePath);
                var config = JsonConvert.DeserializeObject<AppConfig>(json);
                return config ?? new AppConfig();
            }

            return new AppConfig();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading config: {ex.Message}");
            return new AppConfig();
        }
    }

    /// <summary>
    /// Saves configuration to disk
    /// </summary>
    public async Task SaveConfigAsync(AppConfig config)
    {
        try
        {
            if (!Directory.Exists(ConfigDirectory))
            {
                Directory.CreateDirectory(ConfigDirectory);
            }

            var json = JsonConvert.SerializeObject(config, Formatting.Indented);
            await File.WriteAllTextAsync(ConfigFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving config: {ex.Message}");
        }
    }

    /// <summary>
    /// Updates a specific configuration value
    /// </summary>
    public async Task UpdateConfigAsync(Action<AppConfig> updateAction)
    {
        var config = await LoadConfigAsync();
        updateAction(config);
        await SaveConfigAsync(config);
    }
}
