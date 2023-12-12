using Shared.Models.Flyweight;

namespace Shared.Models.Factory
{
    public abstract class ObstacleCreator
    {
        public abstract Obstacle CreateObstacle(int x, int y, ObstacleImageFactory _imageFactory);
    }
}
