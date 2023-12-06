namespace WarGame.API.Iterator;

public class ListAggregate<T> : IAggregate<T> where T : class
{
    readonly List<T> items = new();

    public ListAggregate(List<T> objects)
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
        get { return items[index]; }
        set { items.Insert(index, value); }
    }
}
