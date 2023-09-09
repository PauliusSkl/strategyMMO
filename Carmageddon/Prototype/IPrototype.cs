using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Carmageddon.Forms.Models.Car;

namespace Carmageddon.Forms.Prototype
{
    public interface IPrototype
    {
        public Car MakeShallowCopy();
        public Car MakeDeepCopy(CarSize size);
    }
}
