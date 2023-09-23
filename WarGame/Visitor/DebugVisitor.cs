using WarGame.Forms.Models;
using System.Diagnostics;

namespace WarGame.Forms.Visitor;

public class DebugVisitor : PrintingVisitor
{
    public override void PrintCarInfo(Car car)
    {
        Debug.WriteLine("Car selected: " + car.Health + " " + car.Length);
    }
}
