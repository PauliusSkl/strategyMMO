using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            foreach (var observer in observers)
            {
                observer.OnTurnEnd(); //siunčia eventa 
            }
        }
    }
}
