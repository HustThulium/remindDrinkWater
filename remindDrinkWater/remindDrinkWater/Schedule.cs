using System.Threading;

namespace remindDrinkWater
{
    class Schedule
    {
        private int timeInterval;
        private readonly MainForm mainForm;
        private ThreadStart childref;
        private Thread childThread;
        
        public Schedule(MainForm mainForm)
        {
            this.mainForm = mainForm;
            mainForm.Show_MessageBox();
            this.timeInterval = 45 * 60;
            this.childref = new ThreadStart(remindDrinking);
            this.childThread = new Thread(childref);

        }

        public void startChildThread()
        {
            this.childThread.Start();
        }

        public void stopChildThread()
        {
            this.childThread.Abort();
        }

        private void remindDrinking()
        {
            while (true)
            {
                Thread.Sleep(this.timeInterval * 1000);
                mainForm.Show_MessageBox();
            }
        }

        public int getTimeInterval()
        {
            return this.timeInterval;
        }

        public void setTimeInterval(int timeInterval)
        {
            this.timeInterval = timeInterval;
        }
    }
}
