using Carmageddon.Forms.Prototype;
using Carmageddon.Forms.Visitor;

namespace Carmageddon.Forms.Models
{
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
            return (Car)this.MemberwiseClone();
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

            car.Length = this.Length;
            car.Health = this.Health;
            car.Image = this.Image;
            car.Coordinates = new CarPart[this.Coordinates.Length];
            return car;
        }
    }
}
