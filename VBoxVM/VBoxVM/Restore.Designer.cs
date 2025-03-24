namespace VBoxVM
{
    partial class Restore
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
            main_label = new Label();
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
            // Restore
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(687, 201);
            Controls.Add(main_label);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Restore";
            Text = "Restore";
            ResumeLayout(false);
        }

        #endregion

        private Label main_label;
    }
}