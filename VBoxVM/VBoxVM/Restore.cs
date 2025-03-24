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

            File.Delete(xmlFile);
            File.Move(xmlFileBck, xmlFile);
        }
    }
}
