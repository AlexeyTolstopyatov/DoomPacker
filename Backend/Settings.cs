using System.IO;
using System.Xaml;
using System.Xml.Serialization;

namespace DoomPacker.Backend;

public class Settings
{
    public string PackIconPath { get; set; }
    public string ModPackFolder { get; set; }
    public string LoadOrderListsFolder { get; set; }
    public string ModsFolder { get; set; }

    public void Save(string fileName)
    {
        using StreamWriter streamWriter = new(fileName);
        
        XmlSerializer xmlSerializer = new(typeof(Settings));
        xmlSerializer.Serialize(streamWriter, this);
    }

    private static Settings Read(string fileName)
    {
        using StreamReader streamReader = new(fileName);
        XmlSerializer xmlSerializer = new(typeof(Settings));

        Settings? model = xmlSerializer.Deserialize(streamReader) as Settings;
            
        if (model is null)
        {
            // ну сделайте уж что-нибудь
            throw new XamlException("Settings.Read: Мне здесь очень плохо.");
        }
        return model; 
        // но поскольку вы гарантировано умераете на null,
        // то Read прощает вам это и вы имеете право выдать Settings который не будет null
    }
    /// <summary>
    /// Создает модель настроек лаунчера на основе переданного XML файла
    /// </summary>
    /// <param name="fileName">путь до файла</param>
    /// <exception cref="XamlException">Если не получилось создать модель</exception>
    public Settings(string fileName)
    {
        var model = Read(fileName);
        
        PackIconPath = model.PackIconPath;
        ModPackFolder = model.ModPackFolder;
        LoadOrderListsFolder = model.LoadOrderListsFolder;
        ModsFolder = model.ModsFolder;
    }
    public Settings()
    {
        PackIconPath = string.Empty;
        ModPackFolder = string.Empty;
        LoadOrderListsFolder = string.Empty;
        ModsFolder = string.Empty;
    }
}