using Shared.Models.Strategy;
using System.Drawing;

namespace Shared.Models
{
    public class Water : Obstacle
    {
        public int SlowLevel { get; set; }

        public Water(int x, int y, int slowLevel, Image image)
        {
            X = x;
            Y = y;
            SlowLevel = slowLevel;
            Image = image;
            _effectStrategy = new HealingStrategy();
        }

        public override List<string> DisplayInfo()
        {
            List<string> info = new List<string>();
            info.Add("Name: Water");
            info.Add("Strategy: " + _effectStrategy.GetType());
            info.Add("Cords: " + X.ToString() + ";" + Y.ToString());

            return info;
        }

        public override void SetEffectStrategy(IEffectStrategy effectStrategy)
        {
            this._effectStrategy = effectStrategy;
        }

        protected sealed override void ApplyEffectStrategy(Unit unit)
        {
            _effectStrategy.ApplyEffect(unit);
        }
        protected sealed override bool ValidateObstacle(Unit unit)
        {
            if (unit == null)
            {
                return false;
            }

            return true;
        }
    }
}
