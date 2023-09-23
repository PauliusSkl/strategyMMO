﻿namespace WarGame.Forms.Decorator;

public class WhiteGridDecorator : EnvironmentDecorator
{
    public override Image GetImage()
    {
        var oldImage = base.GetImage();
        Image newImage;
        string backPath = Directory.GetCurrentDirectory() + "\\Resources\\Models\\white.png";
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
