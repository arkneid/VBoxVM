namespace VBoxVM
{
    partial class RestoreView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoreView));
            main_label = new Label();
            btn_restore = new Button();
            ntfIconRestore = new NotifyIcon(components);
            SuspendLayout();
            // 
            // main_label
            // 
            main_label.Dock = DockStyle.Top;
            main_label.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            main_label.Location = new Point(0, 0);
            main_label.Name = "main_label";
            main_label.Size = new Size(687, 53);
            main_label.TabIndex = 5;
            main_label.Text = "\r\nVBox default folder";
            main_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_restore
            // 
            btn_restore.Location = new Point(260, 68);
            btn_restore.Name = "btn_restore";
            btn_restore.Size = new Size(165, 49);
            btn_restore.TabIndex = 6;
            btn_restore.Text = "Restore Old Config";
            btn_restore.UseVisualStyleBackColor = true;
            btn_restore.Click += btn_restore_Click;
            // 
            // ntfIconRestore
            // 
            ntfIconRestore.Icon = (Icon)resources.GetObject("ntfIconRestore.Icon");
            ntfIconRestore.Text = "VBoxVM";
            ntfIconRestore.Visible = true;
            ntfIconRestore.MouseClick += notifyIconRestore_MouseClick;
            // 
            // Restore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 132);
            Controls.Add(btn_restore);
            Controls.Add(main_label);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Restore";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VBoxVM";
            Resize += onResizeRestore;
            ResumeLayout(false);
        }

        #endregion

        private Label main_label;
        private Button btn_restore;
        private NotifyIcon ntfIconRestore;
    }
}