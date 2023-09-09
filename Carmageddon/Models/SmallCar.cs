using Carmageddon.Forms.Visitor;

namespace Carmageddon.Forms.Models
{
    public class SmallCar : Car
    {
        public SmallCar(int health, int length, string image)
        {
            this.Health = health;
            this.Length = length;
            this.Image = image;
            this.Coordinates = new CarPart[length];
        }
        public SmallCar()
        {

        }

        public override void AcceptVisitor(PrintingVisitor visitor)
        {
            visitor.PrintCarInfo(this);
        }
    }
}
