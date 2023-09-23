namespace WarGame.Forms.Composite;

public abstract class Component
{
    protected Button button;

    public Component(Button button)
    {
        this.button = button;
    }

    public abstract void Add(Component component);
    public abstract void Remove(Component component);
    public abstract void Display();
}
