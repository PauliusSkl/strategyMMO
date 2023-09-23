using System.Diagnostics;

namespace WarGame.Forms.Adapter;

public class ConsoleLoggerAdapter : IConsoleLogger
{
    private readonly ConsoleLoggerAdaptee _adaptee = new();

    public void LogMessage(string message, bool inline)
    {
        Debug.WriteLine("Logging messsge: ");
        if (inline)
            ConsoleLoggerAdaptee.PrintInLine(message);
        else
            ConsoleLoggerAdaptee.Print(message);
    }
}
