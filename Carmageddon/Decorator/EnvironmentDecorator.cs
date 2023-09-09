using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Decorator
{
    public abstract class EnvironmentDecorator : EnvironmentComponent
    {
        protected EnvironmentComponent _decorator;
        public void SetComponent(EnvironmentComponent decorator)
        {
            _decorator = decorator;
        }
        public override Image GetImage()
        {
            return _decorator.GetImage();
        }
    }
}
