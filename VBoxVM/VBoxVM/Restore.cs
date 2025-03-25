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
    public partial class Restore : Form
    {
        private string xmlFolder;
        public Restore()
        {
            InitializeComponent();
            this.xmlFolder = $@"C:\Users\{Environment.UserName}\.VirtualBox";
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            string xmlFile = $@"{this.xmlFolder}\VirtualBox.xml";
            string xmlFileBck = $@"{this.xmlFolder}\VirtualBox_bck.xml";

            if (!File.Exists(xmlFileBck))
            {
                MessageBox.Show("The backup file don't exists!", "Backup File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                File.Delete(xmlFile);
                File.Move(xmlFileBck, xmlFile);
                MessageBox.Show("The backup of virtual box config file was restored.", "Restore Virtual Box config file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.WindowState = FormWindowState.Minimized;
            }
            catch (IOException ioex)
            {
                MessageBox.Show(ioex.Message, "Error Writing VirtualBox xml file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void onResizeRestore(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)  // only hide if minimizing the form
            {
                this.ShowInTaskbar = false;
                ntfIconRestore.Visible = true;
                this.Visible = false;
            }
        }

        private void notifyIconRestore_MouseClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;

            this.WindowState = FormWindowState.Normal;
        }
    }
}
