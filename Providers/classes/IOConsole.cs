using Provider;

namespace Providers.classes;

public class IoConsole : IOProvider
{
    public void WriteLine(string message, params object?[] args)
    {
        Console.WriteLine(message, args);
    }

    public void Write(string message, params object?[] args)
    {
        Console.Write(message, args);
    }

    public string? ReadLine()
    {
        return Console.ReadLine();
    }
}