using Carmageddon.Forms.IteratorPattern;
using Carmageddon.Forms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carmageddon.Forms.TemplateMethod
{
    public class OtherCarPlacer : CarPlacer
    {
        public sealed override bool ValidateBorders(Car car)
        {
            var isValid = true;
            foreach (var item in car.Coordinates)
            {
                if (item.CoordX > 450 || item.CoordX < 0 || item.CoordY > 450 || item.CoordY < 0)
                {
                    isValid = false;
                    break;
                }
            }

            return isValid;
        }

        public sealed override bool ValidateCars(Car car, List<Car> cars)
        {
            var isValid = true;

            if (cars.Count == 0)
            {
                return isValid;
            }

            var carAggregate = new GameObjAggregate();
            carAggregate.ListToAggregate(cars);
            var carIterator = carAggregate.CreateIterator();

            var placedCar = (Car)carIterator.First();

            while (placedCar != null)
            {
                var coordsAggregate = new GameObjAggregate();
                coordsAggregate.ListToAggregate(car.Coordinates.ToList());
                var coordsIterator = coordsAggregate.CreateIterator();

                var coord = (CarPart)coordsIterator.First();
                while (coord != null)
                {
                    if (placedCar.Coordinates.Any(x => x.CoordX == coord.CoordX && x.CoordY == coord.CoordY))
                    {
                        isValid = false;
                        break;
                    }
                    coord = (CarPart)coordsIterator.Next();
                }

                if (!isValid)
                {
                    break;
                }

                placedCar = (Car)carIterator.Next();
            }

            return isValid;
        }
    }
}
