namespace Watch.Adapter
{
    public class MoveWatch : IMove
    {
        public void Move(Watch watch)
        { 
            Form1 form = Form1.GetInstanse();
            Graphics graphics = form.pictureBox1.CreateGraphics();

            GetCoordinates getCoordinates = GetCoordinates.GetInstanse();

            var oldSecCoord = getCoordinates.GetCoord(watch.SecDeg / 6, 100 + 4);
            var oldMinCoord = getCoordinates.GetCoord(watch.MinDeg / 6, 90 + 4);
            var oldHourCoord = getCoordinates.GetHourCoord(watch.HourDeg / 30 % 12, watch.MinDeg / 6, 75 + 4);

            graphics.DrawLine(new Pen(Color.White, 30f), new Point(175, 175),
                new Point(oldHourCoord[0], oldHourCoord[1]));
            graphics.DrawLine(new Pen(Color.White, 30f), new Point(175, 175),
                new Point(oldMinCoord[0], oldMinCoord[1]));
            graphics.DrawLine(new Pen(Color.White, 30f), new Point(175, 175),
                new Point(oldSecCoord[0], oldSecCoord[1]));

            var newSecCoord = getCoordinates.GetCoord(watch.SecDeg / 6, 100);
            var newMinCoord = getCoordinates.GetCoord(watch.MinDeg / 6, 90);
            var newHourCoord = getCoordinates.GetHourCoord(watch.HourDeg / 30 % 12, watch.MinDeg / 6, 75);
            
            graphics.DrawLine(new Pen(Color.Pink, 5f), new Point(175, 175),
                new Point(newHourCoord[0], newHourCoord[1]));
            graphics.DrawLine(new Pen(Color.Black, 4f), new Point(175, 175), 
                new Point(newMinCoord[0], newMinCoord[1]));
            graphics.DrawLine(new Pen(Color.Violet, 3f), new Point(175, 175),
                new Point(newSecCoord[0], newSecCoord[1]));
        }
    }
}