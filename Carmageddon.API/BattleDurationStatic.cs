namespace Carmageddon.API
{
    public class BattleDurationStatic
    {
        private static DateTime _battleDuration = DateTime.MinValue;

        public static void CountDuration()
        {
            while (true)
            {
                _battleDuration = _battleDuration.AddSeconds(1);
                Thread.Sleep(1000);
            }
        }

        public static DateTime GetCurrentDuration()
        {
            return _battleDuration;
        }
    }
}
