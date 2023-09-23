namespace WarGame.Forms.Composite;

public class ButtonComposite : Component
{
    readonly List<Component> children = new();

    public ButtonComposite(Button button) : base(button) {}
    public override void Add(Component component)
    {
        children.Add(component);
    }

    public override void Remove(Component component)
    {
        _ = children.Remove(component);
    }

    public override void Display()
    {
        foreach(Component component in children)
        {
            component.Display();
        }
    }
}
