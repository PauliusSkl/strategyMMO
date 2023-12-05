namespace WarGame.API.Iterator;

public interface IAggregate<T> where T : class
{
    Iterator<T> CreateIterator();
}
