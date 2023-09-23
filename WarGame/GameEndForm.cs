namespace WarGame.Forms;

public partial class GameEndForm : Form
{
    public GameEndForm(string message)
    {
        InitializeComponent();
        label1.Text = message;
    }
}
