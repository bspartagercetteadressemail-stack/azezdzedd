using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ValorantPorting.Models;

namespace ValorantPorting.Services;

/// <summary>
/// Service for exporting weapon skins to Blender
/// </summary>
public class ExportService
{
    private readonly ValorantApiService _apiService;
    private readonly CUE4ParseService _cue4ParseService;

    public ExportService(ValorantApiService apiService, CUE4ParseService cue4ParseService)
    {
        _apiService = apiService;
        _cue4ParseService = cue4ParseService;
    }

    /// <summary>
    /// Exports a single weapon skin to Blender
    /// </summary>
    public async Task<bool> ExportSkinToBlenderAsync(WeaponSkin skin, string outputPath)
    {
        try
        {
            Console.WriteLine($"Starting export for: {skin.DisplayName}");

            // Create output directory
            var skinFolder = Path.Combine(outputPath, SanitizeFileName(skin.DisplayName));
            Directory.CreateDirectory(skinFolder);

            // Download display icon
            if (!string.IsNullOrEmpty(skin.DisplayIcon))
            {
                var iconData = await _apiService.DownloadImageAsync(skin.DisplayIcon);
                if (iconData != null)
                {
                    var iconPath = Path.Combine(skinFolder, "icon.png");
                    await File.WriteAllBytesAsync(iconPath, iconData);
                }
            }

            // Extract 3D model if asset path is available
            if (!string.IsNullOrEmpty(skin.AssetPath))
            {
                var modelPath = Path.Combine(skinFolder, $"{SanitizeFileName(skin.DisplayName)}.fbx");
                await _cue4ParseService.ExportToBlenderAsync(skin.AssetPath, modelPath);
            }

            // Create metadata file
            var metadata = new
            {
                skin.Uuid,
                skin.DisplayName,
                skin.AssetPath,
                ExportDate = DateTime.Now,
                Version = "1.0.0"
            };

            var metadataPath = Path.Combine(skinFolder, "metadata.json");
            var metadataJson = JsonConvert.SerializeObject(metadata, Formatting.Indented);
            await File.WriteAllTextAsync(metadataPath, metadataJson);

            Console.WriteLine($"Export completed: {skinFolder}");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error exporting skin: {ex.Message}");
            return false;
        }
    }

    /// <summary>
    /// Exports multiple weapon skins in batch
    /// </summary>
    public async Task<BatchExportResult> BatchExportAsync(List<WeaponSkin> skins, string outputPath)
    {
        var result = new BatchExportResult
        {
            TotalCount = skins.Count,
            SuccessCount = 0,
            FailedCount = 0
        };

        foreach (var skin in skins)
        {
            var success = await ExportSkinToBlenderAsync(skin, outputPath);
            if (success)
            {
                result.SuccessCount++;
            }
            else
            {
                result.FailedCount++;
                result.FailedItems.Add(skin.DisplayName);
            }
        }

        return result;
    }

    /// <summary>
    /// Sanitizes filename by removing invalid characters
    /// </summary>
    private string SanitizeFileName(string fileName)
    {
        var invalidChars = Path.GetInvalidFileNameChars();
        return string.Join("_", fileName.Split(invalidChars, StringSplitOptions.RemoveEmptyEntries));
    }
}

/// <summary>
/// Result of batch export operation
/// </summary>
public class BatchExportResult
{
    public int TotalCount { get; set; }
    public int SuccessCount { get; set; }
    public int FailedCount { get; set; }
    public List<string> FailedItems { get; set; } = new();
}
