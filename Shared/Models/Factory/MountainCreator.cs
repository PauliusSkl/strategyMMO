using Shared.Models.Flyweight;

namespace Shared.Models.Factory
{
    public class MountainCreator : ObstacleCreator
    {
        public override Obstacle CreateObstacle(int x, int y, ObstacleImageFactory _imageFactory)
        {
            return new Mountain(x, y, 2, _imageFactory.GetImage("Resources/obstacle_mountain.png"));
        }
    }
}
