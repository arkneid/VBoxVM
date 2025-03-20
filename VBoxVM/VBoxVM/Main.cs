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

            // Verify if text box is not empty
            if (newLocation == "")
            {
                MessageBox.Show("Text box is empty, please choose folder first!!!", "Error changing default folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Copy file
            try 
            {
                File.Copy(xmlFile, xmlFileBck);
            }
            catch (IOException ioex)
            {
                MessageBox.Show(ioex.Message, "Error copying VirtualBox xml file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
