namespace WarGame.API.Iterator;

public interface IAbstractIterator<T> where T : class
{
    T First();
    T? Next();
    bool IsDone();
    T CurrentItem();
}
