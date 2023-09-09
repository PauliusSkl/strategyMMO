using Carmageddon.Forms.ChainOfResp.Mediator;

namespace Carmageddon.Forms.ChainOfResp
{
    public abstract class ShotEventHandler
    {
        private ShotEventHandler _successor;
        public GridMediator Mediator { get; set; }

        public ShotEventHandler SetSuccessor(ShotEventHandler successor)
        {
            _successor = successor;
            return successor;
        }

        public virtual int HandleShotEvent(Type type, int coordX, int coordY)
        {
            if (_successor != null)
            {
                return _successor.HandleShotEvent(type, coordX, coordY);
            }
            else
            {
                return 0;
            }
        }

        public abstract void Send(string to, (int, int) message, bool isResponse);

        public abstract void Receive(string from, (int,int) message, bool isResponse);
    }
}
