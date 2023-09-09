using Carmageddon.API.Models;

namespace Carmageddon.API.Strategy
{
    public class MovesCount : IStrategy
    {
        public GameStatusModel DoOperation(GameStatusModel model)
        {
            model.MovesCount++;
            return model;
        }
    }
}
