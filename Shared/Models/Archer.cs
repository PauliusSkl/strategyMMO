using Shared.Models.Visitor;

namespace Shared.Models;

public class Archer : Unit, IGuest
{
    public int Arrows { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitArcher(this);
    }
}
