namespace WarGame.Forms.Facade;

// Facade
public class Decision
{
    // Subsystem class
    readonly InputUtils inputUtils = new();

    // Subsystem class
    readonly VisibilityUtils visibilityUtils = new();

    public (bool, bool) ShouldReset(ClickInput input, bool visibility)
    {
        if (InputUtils.InputIsNotEmpty(input) && !VisibilityUtils.IsVisible(visibility))
        {
            return (true, true);
        }
        else if (InputUtils.InputIsNotEmpty(input) && VisibilityUtils.IsVisible(visibility))
        {
            return (true, true);
        }

        return (false, false);
    }
}
