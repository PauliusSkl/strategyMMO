using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Command
{
    public class Receiver
    {
        public Image Action(Stack<Car> cars, Stack<Image> previousImages, Car? car = null, Image? image = null)
        {
            if(car == null || image == null)
            {
                cars.Pop();
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
}
