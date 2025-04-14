using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBoxVM
{
    public class RestoreController
    {
        private readonly IRestoreView? _view;
        private string xmlFolder;

        public RestoreController(IRestoreView? view)
        {
            _view = view;
            MapViewEvents();
            xmlFolder = $@"C:\Users\{Environment.UserName}\.VirtualBox";
        }

        private void MapViewEvents()
        {
            _view.RestoreClickEvent += View_RestoreClickEvent;
        }

        private void View_RestoreClickEvent(object? sender, EventArgs e)
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

            }
            catch (IOException ioex)
            {
                MessageBox.Show(ioex.Message, "Error Writing VirtualBox xml file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception("ioex.Message");
            }
        }
    }
}
