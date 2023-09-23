namespace WarGame.API.State;

public class Healthy : CarState
{
    public override void HandleStateChange(StateContext context, int health)
    {
        if (health == 0)
        {
            context.CarState = new Destroyed();
        }
        else
        {
            context.CarState = new Damaged();
        }
    }
}
