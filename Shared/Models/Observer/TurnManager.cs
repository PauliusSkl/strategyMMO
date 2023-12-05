using WarGame.API.Iterator;

namespace Shared.Models.Observer
{
    public class TurnManager
    {
        private List<ITurnObserver> observers = new List<ITurnObserver>();

        public void RegisterObserver(ITurnObserver observer)
        {
            observers.Add(observer);
        }

        public void UnregisterObserver(ITurnObserver observer)
        {
            observers.Remove(observer);
        }

        public void EndTurn()
        {
            var observersAggregate = new GameObjAggregate<ITurnObserver>(observers);
            var iterator = observersAggregate.CreateIterator();

            while (iterator.IsDone())
            {
                iterator.Next()!.OnTurnEnd();
            }
        }
    }
}
