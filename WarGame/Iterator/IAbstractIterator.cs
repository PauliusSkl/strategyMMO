namespace WarGame.Forms.IteratorPattern;

public interface IAbstractIterator
{
    object First();
    object Next();
    bool IsDone();
    object CurrentItem();
}
