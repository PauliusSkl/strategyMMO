namespace WarGame.Forms.Decorator;

public class ColorDecorator : LabelDecorator
{
    private readonly Color _color;
    public ColorDecorator(AbstractLabel parent, string color) : base(parent)
    {
        _color = color switch
        {
            "green" => Color.Green,
            "blue" => Color.Blue,
            "yellow" => Color.Yellow,
            "red" => Color.Red,
            _ => Color.Black,
        };
    }

    public override void UpdateText(string? text)
    {
        ShowColor();
        base.UpdateText(text);
    }

    private void ShowColor()
    {
        parent.BackColor = _color;
    }
}
