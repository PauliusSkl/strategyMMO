using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Factory
{
    public class MountainCreator : ObstacleCreator
    {
        public override Obstacle CreateObstacle(int x, int y)
        {
            return new Mountain(x, y, 2);
        }
    }
}
