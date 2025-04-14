using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VBoxVM
{
    public partial class RestoreView : Form, IRestoreView
    {
        private string xmlFolder;
        public event EventHandler? RestoreClickEvent;
        private RestoreController _controller;

        public RestoreView()
        {
            InitializeComponent();
            this.xmlFolder = $@"C:\Users\{Environment.UserName}\.VirtualBox";
            this._controller = new RestoreController(this);
            this.ntfIconRestore.Visible = false;
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            MainView MainWindow = new MainView();
            try
            {
                RestoreClickEvent?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
            catch
            {
                return;
            }
        }

        private void onResizeRestore(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)  // only hide if minimizing the form
            {
                this.ShowInTaskbar = false;
                this.ntfIconRestore.Visible = true;
                this.Visible = false;
                this.ntfIconRestore.BalloonTipText = "VBoxVM App Minimized";
                this.ntfIconRestore.BalloonTipTitle = "VBoxVM";
                this.ntfIconRestore.BalloonTipIcon = ToolTipIcon.Info;
                this.ntfIconRestore.ShowBalloonTip(3000);
            }
        }

        private void notifyIconRestore_MouseClick(object sender, MouseEventArgs e)
        {
            string xmlFile = $@"{this.xmlFolder}\VirtualBox_bck.xml";

            if (!File.Exists(xmlFile))
            {
                MainView winMain = new MainView();
                this.Hide();
                winMain.Show();
            }
            else
            {
                this.ShowInTaskbar = true;
                this.Visible = true;

                WindowState = FormWindowState.Normal;
            }
        }
    }
}
