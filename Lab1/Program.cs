using ConsoleApp;
using Data;
using Provider;
using Providers.classes;
using Providers.interfaces;

Console.WriteLine("Введите ваше имя");
var inputPath = "";
var outputPath = "";
string? foregroundColor = null;
string? backgroundColor = null;

IOProvider provider = null;

ISettingsProvider<Settings> settingsProvider = null;


// if (File.Exists($"settings.json") && File.ReadAllLines("settings.json").Length > 0)
// {
//     var data = new JsonSettingProvider(new Settings()).Read();
//     Console.WriteLine(data);
// }
//
//
// if ()
// {
//     var data = new XmlSettingProvider(new Settings()).Read();
//     Console.WriteLine(data);
// }

var name = Console.ReadLine();


Console.WriteLine("Что использовать для хранения данных Json или Xml?");

var storageType = Console.ReadLine()?.ToLower();
if (File.Exists($"settings.{storageType}"))
{
    switch (storageType)
    {
        case "json":
        {
            settingsProvider = new JsonSettingProvider(new Settings());
            break;
        }
        case "xml":
        {
            settingsProvider = new XmlSettingProvider(new Settings());
            break;
        }
    }


    var oldSettings = settingsProvider?.Read();
    var oProvider = oldSettings.ioProviderType;

    switch (oProvider)
    {
        case "file":
        {

            inputPath = oldSettings.InputFile;
            outputPath = oldSettings.OutputFile;
            provider = new IoFile(inputPath, outputPath);

            break;

        }
        case "color console":
        {

            backgroundColor = oldSettings.BgColor;
            // backgroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), back);
            provider = new ColoredConsole()
            {
                ForegroundColor = ConsoleColor.Magenta,
                BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), backgroundColor)
            };
            break;
        }
        case "console":
        {
            provider = new IoConsole();
            break;
        }

    }

    if (oldSettings?.UserName == name)
    {
        Console.WriteLine("Вы авторизированы");
        Console.WriteLine("1) Продолжить с текущими настройками?");
        Console.WriteLine("2) Изменить");
        var answer = Console.ReadLine();
        switch (answer)
        {
            case "1":
            {
                Project.GetInstance(settingsProvider, provider, oldSettings).Run();
                break;
            }
            case "2":
            {
                NewFunction(name, backgroundColor, inputPath, outputPath, storageType, settingsProvider, provider);
                break;
            }
        }
    }
    else
    {
        NewFunction(name, backgroundColor, inputPath, outputPath, storageType, settingsProvider, provider);
    }
}
else
{


    NewFunction(name, backgroundColor, inputPath, outputPath, storageType, settingsProvider, provider);

}

void NewFunction(string? s, string? backgroundColor1, string inputPath1, string outputPath1, string? storageType1, ISettingsProvider<Settings>? settingsProvider1, IOProvider? oProvider)
{

    string? foregroundColor1;
    Console.WriteLine("Что хочешь использовать для взаимодействия (console, file, color console)?");

    var ioWindowType = Console.ReadLine()?.ToLower();


    Console.WriteLine("Время задержки?");

    var delay = Console.ReadLine()?.ToLower();


   

    switch (ioWindowType)
    {
        case "file":
        {
            Console.WriteLine("Введите названия файлов");
            inputPath1 = Console.ReadLine()?.ToLower();
            outputPath1 = Console.ReadLine()?.ToLower();
            oProvider = new IoFile(inputPath1, outputPath1);

            break;

        }
        case "color console":
        {
            Console.WriteLine("Введите цвет шрифта");
            foregroundColor1 = Console.ReadLine();
            // foregroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), str);
            Console.WriteLine("Введите цвет консоли");
            backgroundColor1 = Console.ReadLine();
            // backgroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), back);
            oProvider = new ColoredConsole()
            {
                ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), foregroundColor1),
                BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), backgroundColor1)
            };
            break;
        }
        case "console":
        {
            oProvider = new IoConsole();
            break;
        }
    }
    
    Settings settings = new Settings()
    {
        UserName = s,
        BgColor = backgroundColor1,
        Delay = int.Parse(delay),
        InputFile = inputPath1,
        OutputFile = outputPath1,
        settingProviderType = storageType1,
        ioProviderType = ioWindowType

    };
    switch (storageType1)
    {
        case "json":
        {
            settingsProvider1 = new JsonSettingProvider(settings);
            break;
        }
        case "xml":
        {
            settingsProvider1 = new XmlSettingProvider(settings);
            break;
        }
    }
    settingsProvider1.Updater(settings);
    oProvider.WriteLine($"{settings.UserName}, {settings.Delay}");
    // var str = oProvider.ReadLine();
    // Console.WriteLine(str);


    Project.GetInstance(settingsProvider1, oProvider, settings).Run();
}