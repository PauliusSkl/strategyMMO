using Shared.Models.Flyweight;


namespace Shared.Models.Factory
{
    public class LavaCreator : ObstacleCreator
    {
        public override Obstacle CreateObstacle(int x, int y, ObstacleImageFactory _imageFactory)
        {
            return new Lava(x, y, 10, _imageFactory.GetImage("Resources/obstacle_lava.png"));
        }
    }
}
