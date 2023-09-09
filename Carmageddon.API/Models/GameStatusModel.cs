namespace Carmageddon.API.Models
{
    public class GameStatusModel
    {
        public int PlayerCount { get; set; }
        public DateTime BattleDuration { get; set; }
        public int MovesCount { get; set; }
        public List<string> PlayerNames { get; set; }
    }
}
