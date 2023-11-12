using Shared.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Mountain : Obstacle
    {
        public int Height { get; set; }
        

        public Mountain(int x, int y, int height)
        {
            X = x;
            Y = y;
            Height = height;
            Image = "Resources/obstacle_mountain.png";
            _effectStrategy = new SpeedStrategy();
        }

        public override List<string> DisplayInfo()
        {
            List<string> info = new List<string>();
            info.Add("Name: Mountain");
            info.Add("Strategy: " + _effectStrategy.ToString());
            info.Add("Cords: " + X.ToString() + ";" + Y.ToString());

            return info;
        }

        public override void SetEffectStrategy(IEffectStrategy effectStrategy)
        {
            this._effectStrategy = effectStrategy;
        }

        //public override void ApplyEffect(Unit unit)
        //{
        //    _effectStrategy.ApplyEffect(unit);
        //}
        protected override void ApplyEffectStrategy(Unit unit)
        {
            _effectStrategy.ApplyEffect(unit);
        }

        protected sealed override bool ValidateObstacle(Unit unit)
        {
            if (unit == null)
            {
                return false;
            }

            if(_effectStrategy.GetName() == "Attack" && unit.attackRaised)
            {
                return false;
            }

            if (_effectStrategy.GetName() == "Speed" && unit.speedRaised)
            {
                return false;
            }

            return true;
        }
    }
}
