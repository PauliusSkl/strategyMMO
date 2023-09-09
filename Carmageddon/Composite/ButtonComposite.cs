using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Composite
{
    public class ButtonComposite : Component
    {
        List<Component> children = new List<Component>();

        public ButtonComposite(Button button) : base(button) {}
        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display()
        {
            foreach(Component component in children)
            {
                component.Display();
            }
        }
    }
}
