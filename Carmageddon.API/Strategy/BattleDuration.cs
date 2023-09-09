using Carmageddon.API.Models;

namespace Carmageddon.API.Strategy
{
    public class BattleDuration : IStrategy
    {
        public GameStatusModel DoOperation(GameStatusModel model)
        {
            model.BattleDuration = BattleDurationStatic.GetCurrentDuration();
            return model;
        }
    }
}
