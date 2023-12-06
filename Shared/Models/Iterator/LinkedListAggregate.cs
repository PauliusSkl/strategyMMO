using WarGame.API.Iterator;

namespace Shared.Models.Iterator;

public class LinkedListAggregate<T> : IAggregate<T> where T : class
{
    readonly LinkedList<T> items = new();

    public LinkedListAggregate(LinkedList<T> objects)
    {
        foreach (var obj in objects)
            if (obj != null) items.AddLast(obj);
    }

    public Iterator<T> CreateIterator()
    {
        return new Iterator<T>(this);
    }

    public int Count
    {
        get { return items.Count; }
    }

    public T this[int index]
    {
        get { return items.ElementAt(index); }
        set { items.AddLast(value); }
    }
}

