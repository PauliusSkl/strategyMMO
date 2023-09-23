using WarGame.Forms.Models;

namespace WarGame.Forms.Command;

public abstract class Command
{
    protected Receiver _receiver;
    public Command(Receiver receiver)
    {
        _receiver = receiver;
    }
    public abstract void Execute(Car car, Image image, Stack<Car> cars, Stack<Image> previousImages);
    public abstract Image Undo(Stack<Car> cars, Stack<Image> previousImages);
}
