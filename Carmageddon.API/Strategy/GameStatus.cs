using Carmageddon.API.Models;

namespace Carmageddon.API.Strategy
{
    public class GameStatus
    {
        private IStrategy _strategy;

        public GameStatus(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public GameStatusModel ExecuteStrategy(GameStatusModel model)
        {
            return _strategy.DoOperation(model);
        }
    }
}
