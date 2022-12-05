using System.Xml.Serialization;
using Data;
using Provider;

namespace Providers.interfaces;

public class XmlSettingProvider : ISettingsProvider<Settings>
{
    private Settings _settings;

    public XmlSettingProvider(Settings settings)
    {
        _settings = settings;
    }

    
    
    private XmlSerializer _xmlSerializer = new XmlSerializer(typeof(Settings));

    public Settings? Read()
    {
        using var fs = new FileStream("settings.xml", FileMode.OpenOrCreate);
        var settings = (Settings) _xmlSerializer.Deserialize(fs)! ;
        return settings;
    }

    public void Updater(Settings item)
    {
        var settings = Read() ?? new Settings();

        if (!settings.Equals(item))
        {
            settings = item;
        }

        using var fs = new FileStream("settings.xml", FileMode.OpenOrCreate);
        _xmlSerializer.Serialize(fs, settings);
    }
}