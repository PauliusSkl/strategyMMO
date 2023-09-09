namespace Carmageddon.API.Models
{
    public class Player
    {
        public string Username { get; set; }
        public bool PlayerTurn { get; set; }
        public bool Confirmed { get; set; }
        public List<Car> Cars { get; set; }
    }
}
