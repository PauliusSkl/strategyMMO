using WarGame.Forms.Models;

namespace WarGame.Forms.Visitor;

public class ConsoleVisitor : PrintingVisitor
{
    public override void PrintCarInfo(Car car)
    {
        Console.WriteLine("Car selected: " + car.Health + " " + car.Length);
    }
}
