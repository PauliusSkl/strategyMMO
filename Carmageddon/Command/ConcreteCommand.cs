using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Command
{
    public class ConcreteCommand : Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver)
        {

        }

        public override void Execute(Car car, Image image, Stack<Car> cars, Stack<Image> previousImages)
        {
            _receiver.Action(cars, previousImages, car, image);
        }

        public override Image Undo(Stack<Car> cars, Stack<Image> previousImages)
        {
            var image = _receiver.Action(cars, previousImages);
            return image;
        }
    }
}
