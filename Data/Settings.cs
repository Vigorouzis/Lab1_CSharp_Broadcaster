using System.Xml.Serialization;
using Newtonsoft.Json;
using Provider;

namespace Data;
[Serializable]
[XmlRoot(ElementName = "Settings")]
public class Settings
{
    [JsonProperty("username")]
    public string? UserName;
    [JsonProperty("BgColor")]
    public string? BgColor;
    [JsonProperty("delay")]
    public int Delay;
    [JsonProperty("inputFile")]
    public string? InputFile;
    [JsonProperty("outputFile")]
    public string? OutputFile;
    [JsonProperty("settingProviderType")]
    public string? settingProviderType;
    [JsonProperty("ioProviderType")]
    public string? ioProviderType;
   
}

// public record Settings<T>(string? UserName, string? BgColor, int Delay, string? InputFile, string? OutputFile, IOProvider IoProvider, string? settingProviderType, ISettingsProvider<T>? settingProvider);