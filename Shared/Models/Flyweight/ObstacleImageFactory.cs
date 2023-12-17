using System.Drawing;

namespace Shared.Models.Flyweight;

public class ObstacleImageFactory
{
    private readonly Dictionary<string, Image> images = new(3);

    public Image GetImage(string path)
    {
        if (images.ContainsKey(path))
        {
            return images[path];
        }
        else
        {
            var image = Image.FromFile(path);
            images[path] = image;
            return image;
        }
    }
}
