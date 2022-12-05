using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Provider;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Providers.interfaces;

using Data;

public class JsonSettingProvider : ISettingsProvider<Settings>
{
    private Settings? _settings;

    public JsonSettingProvider(Settings? settings)
    {
        _settings = settings;
    }

    public Settings? Read()
    {
        using var r = new StreamReader("settings.json");
        var json = r.ReadToEnd();
        var settings = JsonConvert.DeserializeObject<Settings>(json);

        return settings;
    }

    public void Updater(Settings item)
    {
        var settings = Read() ?? new Settings();

        if (!settings.Equals(item))
        {
            settings = item;
        }

        var jsonString = JsonConvert.SerializeObject(settings);
        File.WriteAllText(@"settings.json", jsonString);
    }
}