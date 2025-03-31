using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBoxVM
{
    public class MainController
    {
        private readonly IMainView _view;
        private string xmlFolder;

        public MainController(IMainView view)
        {
            _view = view;
            MapViewEvents();
            xmlFolder = $@"C:\Users\{Environment.UserName}\.VirtualBox";
        }

        private void MapViewEvents()
        {
            _view.ChangeClickEvent += View_ButtonChangeClickEvent;
        }

        private void View_ButtonChangeClickEvent(object? sender, EventArgs e)
        {
            string xmlFile = $@"{this.xmlFolder}\VirtualBox.xml";
            string xmlFileBck = $@"{this.xmlFolder}\VirtualBox_bck.xml";
            string newLocation = _view.FolderPath;
            string fileText;
            string tmpText = "";
            string vboxName = "";
            string vboxPath = "";
            List<string> vboxMachineUuid = new List<string>();
            DirectoryInfo newDirInfo;
            
            // Verify if text box is not empty
            if (newLocation == "")
            {
                MessageBox.Show("Text box is empty, please choose folder first!!!", "Error changing default folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verify if folder and file exists
            CheckFolderFile(VmFolder: this.xmlFolder, VmFile: xmlFile);

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

                if (File.Exists($@"{vboxPath}\{vboxName}"))
                {
                    foreach (var line in File.ReadAllLines($@"{vboxPath}\{vboxName}"))
                    {
                        if (line.Contains("<Machine"))
                        {
                            vboxMachineUuid.Add($@"{vboxPath}\{vboxName}" + " - " + line.Substring(line.IndexOf("{"), 38));
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"The .vbox file for the virtual machine {directory.Name} don't exist.\nThis usually means that the virtual machine was removed but not all files were deleted OR the virtual machine is corrupted!", "Check vbox file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
