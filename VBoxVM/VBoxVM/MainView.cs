using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace VBoxVM
{
    public partial class MainView : Form, IMainView
    {
        private string xmlFolder;
        public string FolderPath { get => this.txt_folder_path.Text; }

        public event EventHandler? ChangeClickEvent;
        private MainController _controller;

        public MainView()
        {
            InitializeComponent();
            this.txt_folder_path.ReadOnly = true;
            this.xmlFolder = $@"C:\Users\{Environment.UserName}\.VirtualBox";
            this.ntfIconMain.Visible = false;
            this._controller = new MainController(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                var result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    this.txt_folder_path.Text = fbd.SelectedPath;
                }
            }
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            ChangeClickEvent?.Invoke(this, e);
            this.txt_folder_path.Text = string.Empty;
            WindowState = FormWindowState.Minimized;
        }

        private void onResizeMain(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)  // only hide if minimizing the form
            {
                this.ShowInTaskbar = false;
                this.ntfIconMain.Visible = true;
                this.Visible = false;
                this.ntfIconMain.BalloonTipText = "VBoxVM App Minimized";
                this.ntfIconMain.BalloonTipTitle = "VBoxVM";
                this.ntfIconMain.BalloonTipIcon = ToolTipIcon.Info;
                this.ntfIconMain.ShowBalloonTip(3000);
            }
            else
            {
                this.ShowInTaskbar = true;
                this.ntfIconMain.Visible = false;
                this.Visible = true;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            string xmlFile = $@"{this.xmlFolder}\VirtualBox_bck.xml";

            if (File.Exists(xmlFile))
            {
                RestoreView? restoreView = new RestoreView();
                this.Hide();
                restoreView.ShowDialog();
                restoreView = null;
                this.Show();
                this.ntfIconMain.Visible = false;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                this.ntfIconMain.Visible = false;
                this.ShowInTaskbar = true;
                this.Visible = true;

                WindowState = FormWindowState.Normal;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Environment.Exit(0);
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutView WindowAbout = new AboutView();

            this.Hide();
            WindowAbout.Show();
        }
    }
}
