namespace VBoxVM
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.txt_folder_path.ReadOnly = true;
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
            //TO DO
        }
    }
}
