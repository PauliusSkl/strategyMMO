namespace WarGame.Forms.State;

public class Damaged : CarState
{
    public override void HandleStateChange(StateContext context)
    {
        context.CarState = new Destroyed();
    }
}
