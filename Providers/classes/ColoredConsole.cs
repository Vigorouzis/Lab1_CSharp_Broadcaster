using Provider;

namespace Providers.classes;

public class ColoredConsole : IOProvider
{
    private readonly ConsoleColor _origBackgroundColor;
    private readonly ConsoleColor _origForegroundColor;


    public ConsoleColor BackgroundColor
    {
        get => Console.BackgroundColor;
        set => Console.BackgroundColor = value;
    }

    public ConsoleColor ForegroundColor
    {
        get => Console.ForegroundColor;
        set => Console.ForegroundColor = value;
    }


    public ColoredConsole()
    {
        _origBackgroundColor = Console.BackgroundColor;
        _origForegroundColor = Console.ForegroundColor;
    }

    public void Write(string msg, params object?[] args)
    {
        Console.Write(msg, args);
    }


    public void WriteLine(string msg, params object?[] args)
    {
        Console.WriteLine(msg, args);
    }

    public string? ReadLine()
    {
        return Console.ReadLine();
    }
}