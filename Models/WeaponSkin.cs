using Newtonsoft.Json;
using System.Collections.Generic;

namespace ValorantPorting.Models;

/// <summary>
/// Represents a Valorant weapon skin from the API
/// </summary>
public class WeaponSkin
{
    [JsonProperty("uuid")]
    public string Uuid { get; set; } = string.Empty;

    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonProperty("displayIcon")]
    public string? DisplayIcon { get; set; }

    [JsonProperty("assetPath")]
    public string? AssetPath { get; set; }

    [JsonProperty("contentTierUuid")]
    public string? ContentTierUuid { get; set; }

    [JsonProperty("themeUuid")]
    public string? ThemeUuid { get; set; }

    // For UI display
    public bool IsSelected { get; set; }
}

/// <summary>
/// API response wrapper for weapon skins
/// </summary>
public class WeaponSkinsResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("data")]
    public List<WeaponSkin> Data { get; set; } = new();
}
