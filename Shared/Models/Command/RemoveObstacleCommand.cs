using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Command
{
    public class RemoveObstacleCommand : ICommand
    {
        private readonly List<Obstacle> obstacles;
        private readonly Obstacle obstacle;

        public RemoveObstacleCommand(List<Obstacle> obstacles, Obstacle obstacle)
        {
            this.obstacles = obstacles;
            this.obstacle = obstacle;
        }

        public void Execute()
        {
            obstacles.Remove(obstacle);
        }

        public void Undo()
        {
            obstacles.Add(obstacle);
        }

        public Obstacle Obstacle => obstacle;
    }

}
