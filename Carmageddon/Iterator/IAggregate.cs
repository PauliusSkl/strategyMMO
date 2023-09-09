using Carmageddon.Forms.Proxy;

namespace Carmageddon.Forms.IteratorPattern
{
    public interface IAggregate
    {
        //Iterator CreateIterator();
        IteratorProxy CreateIterator();
    }
}
