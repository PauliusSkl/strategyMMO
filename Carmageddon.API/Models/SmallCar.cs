using Carmageddon.API.State;

namespace Carmageddon.API.Models
{
    public class SmallCar : Car
    {
        public SmallCar(int health, int length, string image)
        {
            this.Health = health;
            this.Length = length;
            this.Image = image;
            this.Coordinates = new CarPart[length];
            this.Context = new StateContext(new Healthy());
        }
    }
}
