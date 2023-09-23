using System.Diagnostics;

namespace WarGame.Forms.Composite;

public class Leaf : Component
{
    public Leaf(Button button):base(button){ }

    public override void Add(Component component)
    {
        Debug.WriteLine("Cannot add to a leaf");
    }

    public override void Remove(Component component)
    {
        Debug.WriteLine("Cannot remove from a leaf");
    }

    public override void Display()
    {
        button.Visible = true;
    }
}
