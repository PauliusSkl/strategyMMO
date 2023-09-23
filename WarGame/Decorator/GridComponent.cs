﻿namespace WarGame.Forms.Decorator;

public class GridComponent : EnvironmentComponent
{
    public Image GridImage { get; set; }

    public override Image GetImage()
    {
        string removePathOld = Directory.GetCurrentDirectory() + "\\Resources\\500x500.png";
        using (var bmpTemp = new Bitmap(removePathOld))
        {
            GridImage = new Bitmap(bmpTemp);
        }
        return GridImage;
    }
}
