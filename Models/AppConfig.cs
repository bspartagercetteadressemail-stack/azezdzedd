using Newtonsoft.Json;

namespace ValorantPorting.Models;

/// <summary>
/// Application configuration stored in AppData
/// </summary>
public class AppConfig
{
    [JsonProperty("valorantPath")]
    public string ValorantPath { get; set; } = string.Empty;

    [JsonProperty("lastExportPath")]
    public string LastExportPath { get; set; } = string.Empty;

    [JsonProperty("autoLoadOnStartup")]
    public bool AutoLoadOnStartup { get; set; } = false;

    [JsonProperty("theme")]
    public string Theme { get; set; } = "Dark";

    [JsonProperty("exportSettings")]
    public ExportSettings ExportSettings { get; set; } = new();

    [JsonProperty("viewSettings")]
    public ViewSettings ViewSettings { get; set; } = new();
}

/// <summary>
/// Export configuration settings
/// </summary>
public class ExportSettings
{
    [JsonProperty("format")]
    public string Format { get; set; } = "FBX";

    [JsonProperty("exportTextures")]
    public bool ExportTextures { get; set; } = true;

    [JsonProperty("textureQuality")]
    public string TextureQuality { get; set; } = "High";

    [JsonProperty("exportMaterials")]
    public bool ExportMaterials { get; set; } = true;

    [JsonProperty("exportAnimations")]
    public bool ExportAnimations { get; set; } = true;

    [JsonProperty("exportLods")]
    public bool ExportLods { get; set; } = false;

    [JsonProperty("scale")]
    public float Scale { get; set; } = 1.0f;
}

/// <summary>
/// View display settings
/// </summary>
public class ViewSettings
{
    [JsonProperty("defaultView")]
    public string DefaultView { get; set; } = "Grid";

    [JsonProperty("gridItemSize")]
    public int GridItemSize { get; set; } = 140;

    [JsonProperty("sortBy")]
    public string SortBy { get; set; } = "Name";

    [JsonProperty("sortAscending")]
    public bool SortAscending { get; set; } = true;

    [JsonProperty("showTooltips")]
    public bool ShowTooltips { get; set; } = true;
}
