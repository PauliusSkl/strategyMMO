using Shared.Models.Strategy;
using System.Drawing;


namespace Shared.Models
{
    public abstract class Obstacle
    {

        public int X { get; set; }

        public int Y { get; set; }

        public string Image { get; set; } = string.Empty;

        public abstract List<string> DisplayInfo();

        public IEffectStrategy _effectStrategy { get; set; }
        public abstract void SetEffectStrategy(IEffectStrategy effectStrategy);

        public void ApplyEffect(Unit unit)
        {
            if(ValidateObstacle(unit) && ValidateIfClose(unit))
            {
                ApplyEffectStrategy(unit);
            }
            
            LogEffectApplied();
        }

        protected abstract bool ValidateObstacle(Unit unit);
        protected abstract void ApplyEffectStrategy(Unit unit);
        protected virtual bool ValidateIfClose(Unit unit)
        {
            int gridSize = 50;

            if(ValidateIfIntersects(unit.X, unit.Y - gridSize))
            {
                return true;
            }

            if (ValidateIfIntersects(unit.X, unit.Y + gridSize))
            {
                return true;
            }

            if (ValidateIfIntersects(unit.X - gridSize, unit.Y))
            {
                return true;
            }

            if(ValidateIfIntersects(unit.X + gridSize, unit.Y))
            {
                return true;
            }

            return false;
        }

        public bool ValidateIfIntersects(int newX, int newY)
        {

            Rectangle attackerBounds = new Rectangle(newX, newY, 40, 40);

            Rectangle obstacleBounds = new Rectangle(this.X, this.Y, 40, 40);

            if (attackerBounds.IntersectsWith(obstacleBounds))
            {
                return true;
            }

            return false;

        }
        

        private void LogEffectApplied()
        {
           
        }
    }
}
