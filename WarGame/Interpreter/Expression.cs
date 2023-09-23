namespace WarGame.Forms.Interpreter;

public abstract class Expression
{
    public abstract void Interpret(InterpreterContext context, SynchronizationContext syncContext, GamePlayForm form);

}
