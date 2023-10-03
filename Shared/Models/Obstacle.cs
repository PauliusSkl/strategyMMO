using Shared.Models.Strategy;
using System.Text.Json.Serialization;


namespace Shared.Models
{
    public abstract class Obstacle
    {

        public int X { get; set; }

        public int Y { get; set; }

        public string Image { get; set; } = string.Empty;

        public abstract List<string> DisplayInfo();

        [JsonIgnore]
        public IEffectStrategy _effectStrategy { get; set; }
        public abstract void SetEffectStrategy(IEffectStrategy effectStrategy);

        public abstract void ApplyEffect(Unit unit);
    }
}
