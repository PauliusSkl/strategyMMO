using Shared.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Shared.Models
{
    public class Water : Obstacle
    {

        public int SlowLevel { get; set; }

        public Water(int x, int y, int slowLevel)
        {
            X = x;
            Y = y;
            SlowLevel = slowLevel;
            Image = "Resources/obstacle_water.png";
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

        public override void ApplyEffect(Unit unit)
        {
            if (_effectStrategy != null)
            {
                this._effectStrategy.ApplyEffect(unit);
            }
        }
    }
}
