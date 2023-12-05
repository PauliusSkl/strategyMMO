using Shared.Models.Visitor;

namespace Shared.Models;

public class Mage : Unit, IGuest
{
    public int Mana { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitMage(this);
    }
}
