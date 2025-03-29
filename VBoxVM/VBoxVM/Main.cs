using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace VBoxVM
{
    public partial class Main : Form
    {
        private string xmlFolder;
        public Main()
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
            string xmlFile = $@"{this.xmlFolder}\VirtualBox.xml";
            string xmlFileBck = $@"{this.xmlFolder}\VirtualBox_bck.xml";
            string newLocation = this.txt_folder_path.Text;
            string fileText;
            string tmpText = "";
            string vboxName = "";
            string vboxPath = "";
            string vboxFileContent;
            List<string> vboxMachineUuid = new List<string>();
            DirectoryInfo newDirInfo;

            // Verify if folder and file exists
            this.CheckFolderFile(VmFolder: this.xmlFolder, VmFile: xmlFile);

            // Verify if text box is not empty
            if (newLocation == "")
            {
                MessageBox.Show("Text box is empty, please choose folder first!!!", "Error changing default folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // File copy
            try
            {
                File.Copy(xmlFile, xmlFileBck);
            }
            catch (IOException ioex)
            {
                MessageBox.Show(ioex.Message, "Error copying VirtualBox xml file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Write file with new information
            fileText = File.ReadAllText(xmlFile);
            newDirInfo = new DirectoryInfo(newLocation);

            foreach (DirectoryInfo directory in newDirInfo.GetDirectories())
            {
                vboxName = $"{directory.Name}.vbox";
                vboxPath = $@"{newLocation}\{directory.Name}";

                foreach (var line in File.ReadAllLines($@"{vboxPath}\{vboxName}"))
                {
                    if (line.Contains("<Machine"))
                    {
                        vboxMachineUuid.Add($@"{vboxPath}\{vboxName}" + " - " + line.Substring(line.IndexOf("{"), 38));
                    }
                }
            }
            foreach (string x in fileText.Split('\n'))
            {
                if (x.Contains("<MachineRegistry"))
                {
                    tmpText += "\t<MachineRegistry>";
                    foreach (string uuid in vboxMachineUuid)
                    {
                        tmpText += $"\n\t  <MachineEntry uuid=\"{uuid.Split(" - ")[1]}\" src=\"{uuid.Split(" - ")[0]}\"/>";
                    }
                    tmpText += "\n\t</MachineRegistry>\n";
                }
                else if (x.Contains("<SystemProperties"))
                {
                    tmpText += $"\t<SystemProperties defaultMachineFolder=\"{newLocation}\" defaultHardDiskFormat=\"VDI\" VRDEAuthLibrary=\"VBoxAuth\" webServiceAuthLibrary=\"VBoxAuth\" LogHistoryCount=\"3\" proxyMode=\"0\" exclusiveHwVirt=\"false\"/>";
                }
                else if (x.Contains("</MachineRegistry>") || x.Contains("<MachineEntry"))
                {
                    continue;
                }
                else
                {
                    tmpText += x + "\n";
                }
            }
            try
            {
                File.WriteAllText(xmlFile, tmpText);
                MessageBox.Show("VirtualBox xml was successfully changed!", "Writing VirtualBox xml file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.WindowState = FormWindowState.Minimized;
            }
            catch (IOException ioex)
            {
                MessageBox.Show(ioex.Message, "Error Writing VirtualBox xml file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckFolderFile(string VmFolder, string VmFile)
        {
            if (Directory.Exists(VmFolder))
            {
                if (!File.Exists(VmFile))
                {
                    File.Create(VmFile);
                }
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(VmFolder);
                    File.Create(VmFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error found while trying to create file or directory:\n{ex}", "Creation of .VirtualBox fodler and VirtualBox.xml file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void onResizeMain(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)  // only hide if minimizing the form
            {
                this.ShowInTaskbar = false;
                ntfIconMain.Visible = true;
                this.Visible = false;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            string xmlFile = $@"{this.xmlFolder}\VirtualBox_bck.xml";

            if (File.Exists(xmlFile))
            {
                Restore winRestore = new Restore();
                ntfIconMain.Visible = false;
                this.Hide();
                winRestore.Show();
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
    }
}
