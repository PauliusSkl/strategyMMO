using Carmageddon.API.Models;

namespace Carmageddon.API.Strategy
{
    public interface IStrategy
    {
        public GameStatusModel DoOperation(GameStatusModel model);
    }
}
