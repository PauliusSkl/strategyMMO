using System.Collections;
using WarGame.API.Iterator;

namespace Shared.Models.Iterator;
public class ArrayListAggregate<T> : IAggregate<T> where T : class
{
    readonly ArrayList items = new();

    public ArrayListAggregate(List<T> objects)
    {
        foreach (var obj in objects)
            if (obj != null) items.Add(obj);
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
        get { return items[index] as T; }
        set { items.Insert(index, value); }
    }
}

