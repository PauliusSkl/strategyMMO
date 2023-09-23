using WarGame.Forms.Models;

namespace WarGame.Forms.Visitor;

public class FileVisitor : PrintingVisitor
{
    private readonly string fileName = "carPlacingLog.txt";
    public override void PrintCarInfo(Car car)
    {
        using var sw = new StreamWriter(fileName, true);
        sw.WriteLine("Car selected: " + car.Health + " " + car.Length + " " + DateTime.Now);
    }
}
