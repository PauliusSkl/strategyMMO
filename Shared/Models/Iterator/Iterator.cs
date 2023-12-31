﻿namespace WarGame.API.Iterator;

public class Iterator<T> : IAbstractIterator<T> where T : class
{
    readonly IAggregate<T> _aggregate;
    int current = 0;

    public Iterator(IAggregate<T> aggregate)
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

        if (current < _aggregate.Count)
        {
            item = _aggregate[current++];
        }

        return item;
    }
}
