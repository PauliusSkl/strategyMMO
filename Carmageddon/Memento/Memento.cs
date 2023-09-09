using Carmageddon.Forms.Command;
using Carmageddon.Forms.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Memento
{
    public class Memento
    {
        Invoker _invoker;
        Image _image;
        Grid _carGrid;

        public Memento(Invoker invoker, Image image, Grid grid)
        {
            _invoker = invoker;
            _image = image;
            _carGrid = grid;
        }
        public Invoker Invoker { get { return _invoker; } set { _invoker = value; } }
        public Image Image { get { return _image; } set { _image = value; } }
        public Grid Grid { get { return _carGrid; } set { _carGrid = value; } }

    }
}
