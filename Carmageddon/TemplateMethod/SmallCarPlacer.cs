using Carmageddon.Forms.IteratorPattern;
using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.TemplateMethod
{
    public class SmallCarPlacer : CarPlacer
    {
        public sealed override bool ValidateBorders(Car car)
        {
            var isValid = true;
            if (car.Coordinates[0].CoordX > 500 || car.Coordinates[0].CoordX < 0 ||
                    car.Coordinates[0].CoordY > 500 || car.Coordinates[0].CoordY < 0)
            {
                isValid = false;
            }

            return isValid;
        }

        public sealed override bool ValidateCars(Car car, List<Car> cars)
        {
            var isValid = true;

            if(cars.Count == 0)
            {
                return isValid;
            }

            var aggregate = new GameObjAggregate();
            aggregate.ListToAggregate(cars);
            var iterator = aggregate.CreateIterator();

            var placedCar = (Car)iterator.First();

            while (placedCar != null)
            {
                if (placedCar.Coordinates.Any(x => x.CoordX == car.Coordinates[0].CoordX &&
                    x.CoordY == car.Coordinates[0].CoordY))
                {
                    isValid = false;
                    break;
                }
                placedCar = (Car)iterator.Next();
            }

            return isValid;
        }
    }
}
