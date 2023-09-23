using WarGame.Forms.Models;

namespace WarGame.Forms.Command;

public class ConcreteCommand : Command
{
    public ConcreteCommand(Receiver receiver) : base(receiver)
    {

    }

    public override void Execute(Car car, Image image, Stack<Car> cars, Stack<Image> previousImages)
    {
        _ = Receiver.Action(cars, previousImages, car, image);
    }

    public override Image Undo(Stack<Car> cars, Stack<Image> previousImages)
    {
        var image = Receiver.Action(cars, previousImages);
        return image;
    }
}
