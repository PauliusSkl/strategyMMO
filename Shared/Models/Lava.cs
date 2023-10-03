using Shared.Models.Strategy;

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
            _effectStrategy = new DebuffEffect();

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

        public override void ApplyEffect(Unit unit)
        {
            if (_effectStrategy != null)
            {
                _effectStrategy.ApplyEffect(unit);
            }
        }
    }
}
