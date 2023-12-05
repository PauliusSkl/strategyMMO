namespace WarGame.API.Iterator;

public class Iterator<T> : IAbstractIterator<T> where T : class
{
    readonly GameObjAggregate<T> _aggregate;
    int current = 0;

    public Iterator(GameObjAggregate<T> aggregate)
    {
        _aggregate = aggregate;
    }

    public T CurrentItem()
    {
        return _aggregate[current];
    }

    public T First()
    {
        return _aggregate[0];
    }

    public bool IsDone()
    {
        return current >= _aggregate.Count;
    }

    public T? Next()
    {
        T? item = null;

        if (current < _aggregate.Count - 1)
        {
            item = _aggregate[++current];
        }

        return item;
    }
}
