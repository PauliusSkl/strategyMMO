namespace WarGame.Forms.Decorator;

public class LabelDecorator : AbstractLabel
{
    protected AbstractLabel parent;

    public LabelDecorator(AbstractLabel parent)
    {
        this.parent = parent;
    }

    public override void UpdateText(string? text)
    {
        parent.UpdateText(text);
    }
}
