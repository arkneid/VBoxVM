using System.Windows.Forms;

namespace VBoxVM
{
    public partial class MainView : Form, IMainView
    {
        private string xmlFolder;
        public string FolderPath => txt_folder_path.Text;
        public event EventHandler? ChangeClickEvent;

        public MainView()
        {
            InitializeComponent();
            this.txt_folder_path.ReadOnly = true;
            this.xmlFolder = $@"C:\Users\{Environment.UserName}\.VirtualBox";
            this.ntfIconMain.Visible = false;
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
            WindowState = FormWindowState.Minimized;
        }

        private void onResizeMain(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)  // only hide if minimizing the form
            {
                this.ShowInTaskbar = false;
                ntfIconMain.Visible = true;
                this.Visible = false;
                this.ntfIconMain.BalloonTipText = "VBoxVM App Minimized";
                this.ntfIconMain.BalloonTipTitle = "VBoxVM";
                this.ntfIconMain.BalloonTipIcon = ToolTipIcon.Info;
                this.ntfIconMain.ShowBalloonTip(5000);
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            string xmlFile = $@"{this.xmlFolder}\VirtualBox_bck.xml";

            if (File.Exists(xmlFile))
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                this.Close();
            }
            else
            {
                this.ShowInTaskbar = true;
                this.Visible = true;

                WindowState = FormWindowState.Normal;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutView WindowAbout = new AboutView();

            this.Hide();
            WindowAbout.Show();
        }
    }
}
