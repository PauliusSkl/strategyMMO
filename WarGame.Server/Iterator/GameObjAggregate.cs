namespace WarGame.API.Iterator;

public class GameObjAggregate : IAggregate
{
    readonly List<object> items = new();

    public Iterator CreateIterator()
    {
        return new Iterator(this);
    }

    public int Count
    {
        get { return items.Count; }
    }

    public object this[int index]
    {
        get { return items[index]; }
        set { items.Insert(index, value); }
    }

    public void ListToAggregate<T>(List<T> objects)
    {
        foreach (object obj in objects)
        {
            items.Add(obj);
        }
    }
}
