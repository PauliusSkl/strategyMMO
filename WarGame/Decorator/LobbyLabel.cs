namespace WarGame.Forms.Decorator;
public class LobbyLabel : AbstractLabel
{
    public override void UpdateText(string? text)
    {
        Text = text == null ? "Hello! Welcome to the Game!" : text;
    }
}
