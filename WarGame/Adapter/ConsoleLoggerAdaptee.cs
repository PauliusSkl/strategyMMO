using System.Diagnostics;

namespace WarGame.Forms.Adapter;

public class ConsoleLoggerAdaptee
{
    public static void Print(string message)
    {
        Debug.WriteLine(message);
    }

    public static void PrintInLine(string message)
    {
        Debug.Write(message);
    }
}
