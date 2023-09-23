namespace WarGame.Forms.Interpreter;

public class CarCountExpression : Expression
{
    public override void Interpret(InterpreterContext context, SynchronizationContext syncContext, GamePlayForm form)
    {
        if(context.Parameter3 > 0)
        {
            Console.WriteLine("Car count: " + context.Parameter3);
        }
        else
        {
            Console.WriteLine("No cars found!");
        }
    }
}
