using WarGame.Forms.Models;
using static WarGame.Forms.Models.Car;

namespace WarGame.Forms.Factory;

public class CarCreator
{
    public static Car CreateCar(CarSize carSize)
    {
        return carSize switch
        {
            CarSize.Small => new SmallCar(1, 1, "small.png"),
            CarSize.Medium => new MediumCar(2, 2, "medium.png"),
            CarSize.Big => new BigCar(3, 3, "big.png"),
            _ => new SmallCar(1, 1, "small.png"),
        };
    }
}
