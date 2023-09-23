using WarGame.Forms.Models;
using System.Diagnostics;

namespace WarGame.Forms.TemplateMethod;

public abstract class CarPlacer
{
    public bool TemplateMethod(Car car, List<Car> cars)
    {
        var borderValidation = ValidateBorders(car);
        var carsValidation = ValidateCars(car, cars);

        if(borderValidation && carsValidation)
        {
            Debug.WriteLine("Car added!");
            return true;
        }
        Debug.WriteLine("Car was not added due to the validation error");
        return false;
    }

    public abstract bool ValidateBorders(Car car);
    public abstract bool ValidateCars(Car car, List<Car> cars);
}
