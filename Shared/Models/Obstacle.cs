using Shared.Models.Strategy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        //public abstract void ApplyEffect(Unit unit);

        public void ApplyEffect(Unit unit)
        {
            if(ValidateObstacle(unit))
            {
                ApplyEffectStrategy(unit);
            }
            
            LogEffectApplied();
        }

        protected virtual bool ValidateObstacle(Unit unit)
        {
            if (unit == null)
            {
                return false;
            }
            return true;
        }

        protected abstract void ApplyEffectStrategy(Unit unit);

        private void LogEffectApplied()
        {
           
        }
    }
}
