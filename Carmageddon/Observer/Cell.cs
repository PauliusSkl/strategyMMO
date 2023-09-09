namespace Carmageddon.Forms.Observer
{
    // concrete OBSERVER / SUBSCRIBER
    internal class Cell : ICell
    {
        private Form2 Form2 { get; set; }
        private string Coordinates { get; set; }
        private int PictureAxisX { get; set; }
        private int PictureAxisY { get; set; }
        private bool IsHit { get; set; }

        public Grid Grid { get; set; }

        public Cell(Grid grid, Form2 form2, string coordinates, int pictureAxisX, int pictureAxisY)
        {
            Grid = grid;
            Form2 = form2;
            Coordinates = coordinates;
            IsHit = false;
            PictureAxisX = pictureAxisX;
            PictureAxisY = pictureAxisY;
        }

        public void CheckIfHit()
        {
            if(Grid.State == Coordinates && !IsHit)
            {
                IsHit = true;
                Form2.AddShot(Coordinates, PictureAxisX, PictureAxisY);
            }
        }

    }
}
