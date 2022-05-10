namespace Watch.Adapter
{
    public class MoveManuallyWatch : IMoveManually
    {
        public void MoveManually(Watch watch)
        {
            Form1 form = Form1.GetInstanse();
            Graphics graphics = form.pictureBox1.CreateGraphics();
            GetCoordinates getCoordinates = GetCoordinates.GetInstanse();

            var l = getCoordinates.GetLastCoord();

            graphics.DrawLine(new Pen(Color.White, 30f), new Point(175, 175), new Point(l[0], l[1]));
            graphics.DrawLine(new Pen(Color.White, 30f), new Point(175, 175), new Point(l[2], l[3]));
            graphics.DrawLine(new Pen(Color.White, 30f), new Point(175, 175), new Point(l[4], l[5]));

            Form1.degs = new int[3] { watch.SecDeg, watch.MinDeg, watch.HourDeg };
            GetCoordinates.coordinates.Clear();
        }
    }
}
