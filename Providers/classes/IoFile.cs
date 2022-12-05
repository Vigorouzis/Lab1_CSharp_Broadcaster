using Provider;

namespace Providers.classes;

public class IoFile : IOProvider
{
    private string _inputPath;
    private string _outputPath;

    public string InputPath
    {
        get => _inputPath;
    }

    public string OutputPath
    {
        get => _outputPath;
    }


    public IoFile(string inputPath, string outputPath)
    {
        _inputPath = inputPath;
        _outputPath = outputPath;
    }


    public void WriteLine(string message, params object?[] args)
    {
        using StreamWriter writer = new StreamWriter(_outputPath, true);
        writer.WriteLine(message, args);
    }

    public void Write(string message, params object?[] args)
    {
        using StreamWriter writer = new StreamWriter(_outputPath, true);
        writer.Write(message, args);
    }

    public string? ReadLine()
    {

        using StreamReader reader = new StreamReader(_inputPath);
        var text = reader.ReadToEnd();
        // Console.WriteLine(text);
        return text;
    }
}