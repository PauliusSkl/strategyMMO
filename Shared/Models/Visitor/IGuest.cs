namespace Shared.Models.Visitor;

public interface IGuest
{
    void Accept(IVisitor visitor);
}
