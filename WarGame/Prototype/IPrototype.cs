using WarGame.Forms.Models;
using static WarGame.Forms.Models.Car;

namespace WarGame.Forms.Prototype;

public interface IPrototype
{
    public Car MakeShallowCopy();
    public Car MakeDeepCopy(CarSize size);
}
