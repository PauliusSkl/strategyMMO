namespace WarGame.API.Iterator;

public interface IAbstractIterator
{
    object First();
    object Next();
    bool IsDone();
    object CurrentItem();
}
