using Shared.Models.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Shared.Models
{
    public class Lava : Obstacle
    {

        public int Damage { get; set; }
        public Lava(int x, int y, int damage)
        {
            X = x;
            Y = y;
            Damage = damage;
            Image = "Resources/obstacle_lava.png";
            _effectStrategy = new DamageStrategy();

        }

        public override List<string> DisplayInfo()
        {
            List<string> info = new List<string>();
            info.Add("Name: Lava");
            info.Add("Strategy: " + _effectStrategy.GetType());
            info.Add("Cords: " + X.ToString() + ";" + Y.ToString());

            return info;
        }

        public override void SetEffectStrategy(IEffectStrategy effectStrategy)
        {
            _effectStrategy = effectStrategy;
        }

        //public override void ApplyEffect(Unit unit)
        //{
        //    if (_effectStrategy != null)
        //    {
        //        _effectStrategy.ApplyEffect(unit);
        //    }
        //}
        protected override void ApplyEffectStrategy(Unit unit)
        {
            _effectStrategy.ApplyEffect(unit);
        }
    }
}
