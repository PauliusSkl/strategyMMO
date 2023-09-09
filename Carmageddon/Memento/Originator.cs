using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carmageddon.Forms.Command;
using Carmageddon.Forms.Observer;

namespace Carmageddon.Forms.Memento
{
    public class Originator
    {
        Invoker _invoker;
        Image _image;
        Grid _carGrid;
        public Invoker Invoker
        {
            get { return _invoker; }
            set { _invoker = value; }
        }
        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }
        public Grid CarGrid
        {
            get { return _carGrid; }
            set { _carGrid = value; }
        }
        public Memento SaveMemento() { return new Memento(_invoker, _image, _carGrid); }
        public void RestoreMemento(Memento memento) { _invoker = memento.Invoker; _image = memento.Image; _carGrid = memento.Grid; }
    }
}
