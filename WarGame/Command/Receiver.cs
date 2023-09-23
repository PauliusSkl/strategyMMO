using WarGame.Forms.Models;

namespace WarGame.Forms.Command;

public class Receiver
{
    public static Image Action(Stack<Car> cars, Stack<Image> previousImages, Car? car = null, Image? image = null)
    {
        if(car == null || image == null)
        {
            _ = cars.Pop();
            return previousImages.Pop();
        }
        else
        {
            cars.Push(car);
            previousImages.Push(image);
            return null;
        }
    }
}
