namespace WarGame.Forms.State;

public class Healthy : CarState
{
    public override void HandleStateChange(StateContext context)
    {
        context.CarState = new Damaged();
    }
}
