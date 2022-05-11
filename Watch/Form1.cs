using Watch.Adapter;

namespace Watch
{
    public partial class Form1 : Form
    {
        public static Watch watch;

        public Form1()
        {
            InitializeComponent();
            watch = new Watch(DateTime.Now.Second * 6, DateTime.Now.Minute * 6,
                DateTime.Now.Hour * 30 > 360 ? DateTime.Now.Hour * 30 - 360 : DateTime.Now.Hour * 30);
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
                int houdDeg = Convert.ToInt32(time[0]) * 30 > 360
                    ? Convert.ToInt32(time[0]) * 30 - 360
                    : Convert.ToInt32(time[0]) * 30;

                if (minDeg >= 360 || secDeg >= 360)
                {
                    return;
                }

                watch.SecDeg = secDeg;
                watch.MinDeg = minDeg;
                watch.HourDeg = houdDeg;

                IMove moveManually = new Adapter.Adapter();
                watch.Move(moveManually);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IMove moveWatch = new MoveWatch();
            watch.SecDeg += 6;

            if (watch.SecDeg % 360 == 0)
            {
                watch.SecDeg = 0;
                watch.MinDeg += 6;
            }
            
            watch.Move(moveWatch);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }
    }
}