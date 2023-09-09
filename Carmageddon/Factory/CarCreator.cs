using Carmageddon.Forms.Models;
using static Carmageddon.Forms.Models.Car;

namespace Carmageddon.Forms.Factory
{
    public class CarCreator
    {
        public Car CreateCar(CarSize carSize)
        {
            switch (carSize)
            {
                case CarSize.Small:
                    return new SmallCar(1, 1, "small.png");
                case CarSize.Medium:
                    return new MediumCar(2, 2, "medium.png");
                case CarSize.Big:
                    return new BigCar(3, 3, "big.png");
                default:
                    return new SmallCar(1, 1, "small.png");
            }
        }
    }
}
