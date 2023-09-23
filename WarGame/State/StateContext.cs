namespace WarGame.Forms.State;

public class StateContext
{
    CarState state;

    public StateContext(CarState state)
    {
        this.state = state;
    }

    public CarState CarState
    {
        get { return state; }
        set
        {
            state = value;
            Console.WriteLine("Car state: " + state.GetType().Name);
        }
    }

    public void ChangeState()
    {
        state.HandleStateChange(this);
    }
}
