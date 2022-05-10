namespace Watch
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Form1 form = Form1.GetInstanse();
            Application.Run(form);
        }
    }
}