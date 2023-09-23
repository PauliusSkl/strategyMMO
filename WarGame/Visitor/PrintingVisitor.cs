using WarGame.Forms.Models;

namespace WarGame.Forms.Visitor;

public abstract class PrintingVisitor
{
    public abstract void PrintCarInfo(Car car);
}
