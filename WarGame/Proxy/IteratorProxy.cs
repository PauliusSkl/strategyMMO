using WarGame.Forms.IteratorPattern;

namespace WarGame.Forms.Proxy;

public class IteratorProxy : IAbstractIterator
{
    private static GameObjAggregate _aggregate;
    private readonly Iterator iterator;
    private readonly object _lock = new();


    public IteratorProxy(GameObjAggregate aggregate)
    {
        _aggregate = aggregate;
        lock (_lock)
        {
            if (iterator == null)
            {
                iterator = new Iterator(aggregate);
            }
        }
    }

    public object CurrentItem()
    {
        return iterator.CurrentItem();
    }

    public object First()
    {
        return iterator.First();
    }

    public bool IsDone()
    {
        return iterator.IsDone();
    }

    public object Next()
    {
        return iterator.Next();
    }
}
