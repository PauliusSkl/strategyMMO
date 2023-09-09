using Carmageddon.Forms.Visitor;

namespace Carmageddon.Forms.Models
{
    public class MediumCar : Car
    {
        public MediumCar(int health, int length, string image)
        {
            this.Health = health;
            this.Length = length;
            this.Image = image;
            this.Coordinates = new CarPart[length];
        }
        public MediumCar()
        {

        }

        public override void AcceptVisitor(PrintingVisitor visitor)
        {
            visitor.PrintCarInfo(this);
        }
    }
}
