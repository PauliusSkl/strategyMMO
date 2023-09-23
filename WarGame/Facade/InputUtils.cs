namespace WarGame.Forms.Facade;

// Subsystem class
public class InputUtils
{
    // Subsystem method
    public static bool InputIsNotEmpty(ClickInput input)
    {
        if (input != null)
        {
            return true;
        }

        return false;
    }
}
