namespace WarGame.API.Iterator;

public interface IAggregate<T> where T : class
{
    T this[int index] { get; set; }

    int Count { get; }

    Iterator<T> CreateIterator();
}
