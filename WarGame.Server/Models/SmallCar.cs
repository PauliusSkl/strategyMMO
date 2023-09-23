using WarGame.API.State;

namespace WarGame.API.Models;

public class SmallCar : Car
{
    public SmallCar(int health, int length, string image)
    {
        Health = health;
        Length = length;
        Image = image;
        Coordinates = new CarPart[length];
        Context = new StateContext(new Healthy());
    }
}
