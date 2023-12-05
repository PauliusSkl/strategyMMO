using Shared.Models.Visitor;

namespace Shared.Models;
public class Tank : Unit, IGuest
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitTank(this);
    }
}
