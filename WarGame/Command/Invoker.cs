using WarGame.Forms.Models;

namespace WarGame.Forms.Command;

public class Invoker
{
    public Command _command;
    Receiver receiver = new();
    Stack<Image> previousImages = new();
    Stack<Car> _cars = new();
    int count = 0;
    public Invoker(Command command)
    {
        _command = command;
    }
    public void AddCar(Car car, Image image)
    {
        _command.Execute(car, image, _cars, previousImages);
        count++;
    }
    public Image Undo()
    {
       if(count > 0)
        {
            count--;
            return _command.Undo(_cars, previousImages);
        }
       else
            return null;
    }
    public Stack<Car> CarStack()
    {
        return _cars;
    }
    public Image LastImage()
    {
        return previousImages.Peek();
    }
    public object Clone()
    {
        return new Invoker(_command)
        {
            _command = _command,
            receiver = receiver,
            previousImages = new Stack<Image>(new Stack<Image>(previousImages)),
            _cars = new Stack<Car>(new Stack<Car>(_cars)),
            count = count
        };

    }
}
