namespace Watch
{
    public class GetCoordinates
    {
        public static List<int> coordinates;

        private static GetCoordinates instanse;

        public static GetCoordinates GetInstanse()
        {
            if (instanse == null)
            {
                instanse = new GetCoordinates();
                coordinates = new List<int>();
            }
            return instanse;
        }

        public int[] GetCoord(int val, int hlen)
        {
            int[] coord = new int[2];
            val *= 6;
            
            if (val >= 0 && val <= 180)
            {
                coord[0] = 175 + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = 175 - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = 175 - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = 175 - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            coordinates.Add(coord[0]);
            coordinates.Add(coord[1]);
            return coord;
        }

        public int[] GetHourCoord(int hval, int mval, int hlen)
        {
            int[] coord = new int[2];
            int val = (int)((hval * 30) + (mval * 0.5));

            if (val >= 0 && val <= 180)
            {
                coord[0] = 175 + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = 175 - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = 175 - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = 175 - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            coordinates.Add(coord[0]);
            coordinates.Add(coord[1]);
            return coord;
        }

        public List<int> GetLastCoord()
        {
            return coordinates.TakeLast(6).ToList();
        }
    }
}
