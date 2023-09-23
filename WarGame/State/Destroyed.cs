namespace WarGame.Forms.State;

public class Destroyed : CarState
{
    public override void HandleStateChange(StateContext context)
    {
        context.CarState = null;
    }
}
