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
