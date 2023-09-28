using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shared.Models.Factory
{
    public class LavaCreator : ObstacleCreator
    {
        public override Obstacle CreateObstacle(int x, int y)
        {
            return new Lava(x, y, 10);
        }
    }
}
