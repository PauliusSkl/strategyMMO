namespace WarGame.Forms.Memento;

public class Caretaker
{
    Memento memento;
    public Memento Memento
    {
        set { memento = value; }
        get { return memento; }
    }
}
