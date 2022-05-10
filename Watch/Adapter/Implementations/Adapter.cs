namespace Watch.Adapter
{
    public class Adapter : IMove
    {
        private MoveManuallyWatch move;

        public Adapter()
        {
            move = new MoveManuallyWatch();
        }

        public void Move(Watch watch)
        {
            move.MoveManually(watch);
        }
    }
}
