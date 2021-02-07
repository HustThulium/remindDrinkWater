using System;
using System.Windows.Forms;

namespace remindDrinkWater
{
    public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		public void Show_MessageBox()
        {
			MessageBox.Show("兄弟该喝水了！", "系统提示",
					MessageBoxButtons.OK, MessageBoxIcon.Warning,
					MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
		}

		private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.Opacity == 0)
			{
				this.Opacity = 1;
			}
            if (this.Visible == true)
            {
                this.Hide();
                this.ShowInTaskbar = false;
            }
            else
            {
                this.Visible = true;
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
                this.Show();
                this.BringToFront();
            }
        }

		private void Smi_exit_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("是否退出程序？", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
			if (result == DialogResult.OK)
			{
				// 关闭所有的线程
				this.Dispose();
				this.Close();
			}
		}

		private void MainFrom_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.notifyIcon1.ShowBalloonTip(1000, "已最小化至通知区域", "右键点击图标退出程序", ToolTipIcon.Info);//显示气泡提示
				e.Cancel = true;
				this.Visible = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

        private void MainFrom_Load(object sender, EventArgs e)
        {
			BeginInvoke(new MethodInvoker(delegate
			{
				Hide();
			}));
			this.notifyIcon1.ShowBalloonTip(1000, "已最小化至通知区域", "双击图标打开程序", ToolTipIcon.Info);//显示气泡提示
		}
    }
}
