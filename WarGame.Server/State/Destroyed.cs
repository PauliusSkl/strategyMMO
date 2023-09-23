namespace WarGame.API.State;

public class Destroyed : CarState
{
    public override void HandleStateChange(StateContext context, int health)
    {
        context.CarState = null;
    }
}
