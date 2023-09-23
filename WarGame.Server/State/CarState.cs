namespace WarGame.API.State;

public abstract class CarState
{
    public abstract void HandleStateChange(StateContext context, int health);
}
