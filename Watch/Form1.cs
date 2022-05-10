using Watch.Adapter;

namespace Watch
{
    public partial class Form1 : Form
    {
        public static int[] degs;

        public Form1()
        {
            InitializeComponent();
            degs = new int[3];
            degs[0] = DateTime.Now.Second * 6;
            degs[1] = DateTime.Now.Minute * 6;
            degs[2] = DateTime.Now.Hour * 30 > 360 ? DateTime.Now.Hour * 30 - 360 : DateTime.Now.Hour * 30;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 2 || textBox1.Text.Length == 5)
            {
                textBox1.AppendText(":");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var time = textBox1.Text.Split(':');
            textBox1.Clear();
            
            if(time.Length == 3)
            {
                int secDeg = Convert.ToInt32(time[2]) * 6;
                int minDeg = Convert.ToInt32(time[1]) * 6;
                int houdDeg = Convert.ToInt32(time[0]) * 30 > 360 ? Convert.ToInt32(time[0]) * 30 - 360 : Convert.ToInt32(time[0]) * 30;

                if (minDeg >= 360 || secDeg >= 360)
                {
                    return;
                }

                degs[0] = secDeg;
                degs[1] = minDeg;
                degs[2] = houdDeg;

                IMove moveManually = new Adapter.Adapter();
                Watch watch = new Watch(secDeg, minDeg, houdDeg);
                watch.Move(moveManually);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IMove moveWatch = new MoveWatch();
            degs[0] += 6;

            if (degs[0] % 360 == 0)
            {
                degs[0] = 0;
                degs[1] += 6;
            }

            Watch watch = new Watch(degs[0], degs[1], degs[2]);
            watch.Move(moveWatch);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }
    }
}