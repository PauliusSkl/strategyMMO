using WarGame.Forms.Prototype;
using WarGame.Forms.Visitor;

namespace WarGame.Forms.Models;

public abstract class Car : IPrototype
{
    public enum CarSize
    {
        Small,
        Medium,
        Big,
    }

    public int Health { get; set; }
    public int Length { get; set; }
    public string Image { get; set; }
    public CarPart[] Coordinates { get; set; }

    public abstract void AcceptVisitor(PrintingVisitor visitor);

    public (int, int, string) GetInfo()
    {
        return (Health, Length, Image);
    }

    public Car MakeShallowCopy()
    {
        return (Car)MemberwiseClone();
    }

    public Car MakeDeepCopy(CarSize size)
    {
        Car car;
        switch (size)
        {
            case CarSize.Small:
                car = new SmallCar();
                break;
            case CarSize.Medium:
                car = new MediumCar();
                break;
            case CarSize.Big:
                car = new BigCar();
                break;
            default:
                return null;
        }

        car.Length = Length;
        car.Health = Health;
        car.Image = Image;
        car.Coordinates = new CarPart[Coordinates.Length];
        return car;
    }
}
