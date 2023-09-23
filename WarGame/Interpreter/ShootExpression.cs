namespace WarGame.Forms.Interpreter;

public class ShootExpression : Expression
{
    public override void Interpret(InterpreterContext context, SynchronizationContext syncContext, GamePlayForm form)
    {
        (int x, int y) = ConvertCoordinates(context.Parameter1, context.Parameter2);
        var eventArgs = new MouseEventArgs(new MouseButtons(), 0, x, y, 0);

        syncContext.Post(form.ConsoleShoot, eventArgs);

        Console.WriteLine("\nBOOM!\n");
    }

    private static (int, int) ConvertCoordinates(char x, char y)
    {
        var coordX = x switch
        {
            'A' => 1,
            'B' => 51,
            'C' => 101,
            'D' => 151,
            'E' => 201,
            'F' => 251,
            'G' => 301,
            'H' => 351,
            'I' => 401,
            'J' => 451,
            _ => 1,
        };
        var coordY = y switch
        {
            '1' => 1,
            '2' => 51,
            '3' => 101,
            '4' => 151,
            '5' => 201,
            '6' => 251,
            '7' => 301,
            '8' => 351,
            '9' => 401,
            '0' => 451,
            _ => 1,
        };
        return (coordX, coordY);
    }

}
