using Newtonsoft.Json;
using System.Collections.Generic;

namespace ValorantPorting.Models;

/// <summary>
/// Represents a Valorant agent from the API
/// </summary>
public class Agent
{
    [JsonProperty("uuid")]
    public string Uuid { get; set; } = string.Empty;

    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonProperty("displayIcon")]
    public string? DisplayIcon { get; set; }

    [JsonProperty("displayIconSmall")]
    public string? DisplayIconSmall { get; set; }

    [JsonProperty("bustPortrait")]
    public string? BustPortrait { get; set; }

    [JsonProperty("fullPortrait")]
    public string? FullPortrait { get; set; }

    [JsonProperty("assetPath")]
    public string? AssetPath { get; set; }

    [JsonProperty("role")]
    public AgentRole? Role { get; set; }
}

public class AgentRole
{
    [JsonProperty("displayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonProperty("displayIcon")]
    public string? DisplayIcon { get; set; }
}

/// <summary>
/// API response wrapper for agents
/// </summary>
public class AgentsResponse
{
    [JsonProperty("status")]
    public int Status { get; set; }

    [JsonProperty("data")]
    public List<Agent> Data { get; set; } = new();
}
