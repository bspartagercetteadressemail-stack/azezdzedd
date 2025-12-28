using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ValorantPorting.Models;

namespace ValorantPorting.Services;

/// <summary>
/// Service for interacting with valorant-api.com
/// </summary>
public class ValorantApiService
{
    private static readonly HttpClient HttpClient = new();
    private const string BaseUrl = "https://valorant-api.com/v1";

    /// <summary>
    /// Fetches all weapon skins from the API
    /// </summary>
    public async Task<List<WeaponSkin>> GetWeaponSkinsAsync()
    {
        try
        {
            var response = await HttpClient.GetStringAsync($"{BaseUrl}/weapons/skins");
            var weaponSkinsResponse = JsonConvert.DeserializeObject<WeaponSkinsResponse>(response);

            if (weaponSkinsResponse?.Data != null)
            {
                // Filter out skins without display icons
                return weaponSkinsResponse.Data
                    .Where(s => !string.IsNullOrEmpty(s.DisplayIcon))
                    .ToList();
            }

            return new List<WeaponSkin>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching weapon skins: {ex.Message}");
            // Return sample data for fallback
            return GetSampleWeaponSkins();
        }
    }

    /// <summary>
    /// Fetches all agents from the API
    /// </summary>
    public async Task<List<Agent>> GetAgentsAsync()
    {
        try
        {
            var response = await HttpClient.GetStringAsync($"{BaseUrl}/agents?isPlayableCharacter=true");
            var agentsResponse = JsonConvert.DeserializeObject<AgentsResponse>(response);

            return agentsResponse?.Data ?? new List<Agent>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching agents: {ex.Message}");
            return new List<Agent>();
        }
    }

    /// <summary>
    /// Downloads an image from a URL
    /// </summary>
    public async Task<byte[]?> DownloadImageAsync(string url)
    {
        try
        {
            return await HttpClient.GetByteArrayAsync(url);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error downloading image: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Provides sample weapon skins for fallback
    /// </summary>
    private List<WeaponSkin> GetSampleWeaponSkins()
    {
        var samples = new List<WeaponSkin>();
        var sampleNames = new[]
        {
            "Prime Vandal", "Reaver Vandal", "Elderflame Vandal", "Glitchpop Vandal",
            "Phantom", "Operator", "Sheriff", "Ghost", "Classic",
            "Spectre", "Stinger", "Guardian", "Marshal", "Ares"
        };

        for (int i = 0; i < sampleNames.Length; i++)
        {
            samples.Add(new WeaponSkin
            {
                Uuid = Guid.NewGuid().ToString(),
                DisplayName = sampleNames[i],
                DisplayIcon = "https://via.placeholder.com/140x140/FF4655/FFFFFF?text=" + Uri.EscapeDataString(sampleNames[i]),
                AssetPath = $"/Game/Weapons/{sampleNames[i].Replace(" ", "")}"
            });
        }

        return samples;
    }
}
