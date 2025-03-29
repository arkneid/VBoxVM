using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VBoxVM
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Main WindowMain = new Main();

            this.Hide();
            WindowMain.Show();
        }

        private void LinkLabelHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = LinkLabelHome.Text;
            myProcess.Start();
            myProcess.WaitForExit();
            myProcess.Close();
        }

        private void LinkLblGetHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = LinkLblGetHelp.Text;
            myProcess.Start();
            myProcess.WaitForExit();
            myProcess.Close();
        }
    }
}
