using WarGame.API.State;

namespace WarGame.API.Models;

public class Car
{
    public int Health { get; set; }
    public int Length { get; set; }
    public string Image { get; set; }
    public StateContext Context = new(new Healthy());
    public CarPart[] Coordinates { get; set; }
}
