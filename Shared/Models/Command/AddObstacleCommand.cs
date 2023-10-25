using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Command
{
    public class AddObstacleCommand : ICommand
    {
        private readonly List<Obstacle> obstacles;
        private readonly Obstacle obstacle;

        public AddObstacleCommand(List<Obstacle> obstacles, Obstacle obstacle)
        {
            this.obstacles = obstacles;
            this.obstacle = obstacle;
        }

        public void Execute()
        {
            obstacles.Add(obstacle);
        }

        public void Undo()
        {
            obstacles.Remove(obstacle);
        }

        // Add this property to access the obstacle
        public Obstacle Obstacle => obstacle;
    }
}
