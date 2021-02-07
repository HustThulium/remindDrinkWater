using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace remindDrinkWater
{
	static class Program
	{
        private static MainForm mainForm;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			mainForm = new MainForm();
			Schedule schedule = new Schedule(mainForm);
			schedule.startChildThread();
			Application.Run(mainForm);
			schedule.stopChildThread();
		}
	}
}
