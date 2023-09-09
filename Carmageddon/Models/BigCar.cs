using Carmageddon.Forms.Visitor;

namespace Carmageddon.Forms.Models
{
    public class BigCar : Car
    {
        public BigCar(int health, int length, string image)
        {
            this.Health = health;
            this.Length = length;
            this.Image = image;
            this.Coordinates = new CarPart[length];
        }
        public BigCar()
        {

        }

        public override void AcceptVisitor(PrintingVisitor visitor)
        {
            visitor.PrintCarInfo(this);
        }
    }
}
