namespace WarGame.Forms.ChainOfResp.Mediator;

public abstract class AbstractGridMediator
{
    public abstract void Register(ShotEventHandler participant);
    
    public abstract void Send(string from, string to, (int,int) message, bool isResponse);
}
