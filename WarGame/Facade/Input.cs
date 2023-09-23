namespace WarGame.Forms.Facade;

public class ClickInput
{
    private readonly string value;

    public ClickInput(string value)
    {
        this.value = value;
    }

    public string Value { get { return value; } }
}
