namespace Provider;

public interface IOProvider
{
    void WriteLine(string message, params object?[] args);
    void Write(string message, params object?[] args);
    string? ReadLine();
}