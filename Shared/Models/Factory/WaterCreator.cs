using Shared.Models.Flyweight;

namespace Shared.Models.Factory
{
    public class WaterCreator : ObstacleCreator
    {
        public override Obstacle CreateObstacle(int x, int y, ObstacleImageFactory _imageFactory)
        {
            return new Water(x, y, 5, _imageFactory.GetImage("Resources/obstacle_water.png"));
        }
    }
}
