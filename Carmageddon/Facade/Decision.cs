namespace Carmageddon.Forms.Facade
{
    // Facade
    public class Decision
    {
        // Subsystem class
        InputUtils inputUtils = new();

        // Subsystem class
        VisibilityUtils visibilityUtils = new();

        public (bool, bool) ShouldReset(ClickInput input, bool visibility)
        {
            if (inputUtils.InputIsNotEmpty(input) && !visibilityUtils.IsVisible(visibility))
            {
                return (true, true);
            }
            else if (inputUtils.InputIsNotEmpty(input) && visibilityUtils.IsVisible(visibility))
            {
                return (true, true);
            }

            return (false, false);
        }
    }
}
