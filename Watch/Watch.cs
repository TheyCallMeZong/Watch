using Watch.Adapter;

namespace Watch
{
    public class Watch
    {
        public int SecDeg { get; set; } = 0;
        public int MinDeg { get; set; } = 0;
        public int HourDeg { get; set; } = 0;

        public Watch(int secDeg, int minDeg, int hourDeg)
        {
            SecDeg = secDeg;
            MinDeg = minDeg;
            HourDeg = hourDeg;
        }

        public void Move(IMove move)
        {
            move.Move(this);
        }
    }
}
