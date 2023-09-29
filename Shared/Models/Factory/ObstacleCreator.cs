using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Factory
{
    public abstract class ObstacleCreator
    {
        public abstract Obstacle CreateObstacle(int x, int y);
    }
}
