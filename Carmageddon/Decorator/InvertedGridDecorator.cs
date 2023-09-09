using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.Decorator
{
    public class InvertedGridDecorator : EnvironmentDecorator
    {
        public override Image GetImage()
        {
            var oldImage = base.GetImage();
            Image newImage;
            string backPath = Directory.GetCurrentDirectory() + "\\Resources\\Models\\inverted.png";
            using (var bmpTemp = new Bitmap(backPath))
            {
                newImage = new Bitmap(bmpTemp);
            }
            if (oldImage.Equals(newImage))
            {
                return oldImage;
            }
            return newImage;
        }
    }
}
