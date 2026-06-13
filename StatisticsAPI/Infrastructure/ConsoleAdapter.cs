using StatisticsAPI.Abstractions;

namespace StatisticsAPI.Infrastructure;

public class ConsoleAdapter : IConsole
{
    public string ReadLine()
    {
        return Console.ReadLine();
    }

    public void Write(string text)
    {
        Console.Write(text);
    }

    public void WriteLine(string text)
    {
        Console.WriteLine(text);
    }
}