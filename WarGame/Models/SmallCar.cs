using WarGame.Forms.Visitor;

namespace WarGame.Forms.Models;

public class SmallCar : Car
{
    public SmallCar(int health, int length, string image)
    {
        Health = health;
        Length = length;
        Image = image;
        Coordinates = new CarPart[length];
    }
    public SmallCar()
    {

    }

    public override void AcceptVisitor(PrintingVisitor visitor)
    {
        visitor.PrintCarInfo(this);
    }
}
