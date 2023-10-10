namespace WarGame.Forms.Decorator;
public class PlayerCountDecorator : LabelDecorator
{
    private readonly int playerCount = 0;

    public PlayerCountDecorator(AbstractLabel parent, int playerCount) : base(parent)
    {
        this.playerCount = playerCount;
    }

    public override void UpdateText(string? text = null)
    {
        base.UpdateText(DisplayPlayerCount());
    }

    private string DisplayPlayerCount()
    {
        return $"{playerCount}/4 players connected";
    }
}
