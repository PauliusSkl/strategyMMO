using WarGame.Forms.Visitor;

namespace WarGame.Forms.Models;

public class MediumCar : Car
{
    public MediumCar(int health, int length, string image)
    {
        Health = health;
        Length = length;
        Image = image;
        Coordinates = new CarPart[length];
    }
    public MediumCar()
    {

    }

    public override void AcceptVisitor(PrintingVisitor visitor)
    {
        visitor.PrintCarInfo(this);
    }
}
