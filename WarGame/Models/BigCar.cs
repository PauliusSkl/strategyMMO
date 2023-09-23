using WarGame.Forms.Visitor;

namespace WarGame.Forms.Models;

public class BigCar : Car
{
    public BigCar(int health, int length, string image)
    {
        Health = health;
        Length = length;
        Image = image;
        Coordinates = new CarPart[length];
    }
    public BigCar()
    {

    }

    public override void AcceptVisitor(PrintingVisitor visitor)
    {
        visitor.PrintCarInfo(this);
    }
}
