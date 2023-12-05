using Shared.Models.Visitor;

namespace Shared.Models;
public class Warrior : Unit, IGuest
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitWarrior(this);
    }
}
