using WarGame.Forms.Proxy;

namespace WarGame.Forms.IteratorPattern;

public interface IAggregate
{
    //Iterator CreateIterator();
    IteratorProxy CreateIterator();
}
