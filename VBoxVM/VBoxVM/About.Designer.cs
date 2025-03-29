namespace VBoxVM
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            LblAbout = new Label();
            LinkLblGetHelp = new LinkLabel();
            LinkLabelHome = new LinkLabel();
            SuspendLayout();
            // 
            // LblAbout
            // 
            LblAbout.AutoSize = true;
            LblAbout.Location = new Point(12, 9);
            LblAbout.Name = "LblAbout";
            LblAbout.Size = new Size(179, 100);
            LblAbout.TabIndex = 0;
            LblAbout.Text = "Author: Arkneid\r\nVersion: v2.0\r\nRelease Date: 30/03/2024\r\nHome:\r\nGet Help:";
            // 
            // LinkLblGetHelp
            // 
            LinkLblGetHelp.AutoSize = true;
            LinkLblGetHelp.Location = new Point(80, 89);
            LinkLblGetHelp.Name = "LinkLblGetHelp";
            LinkLblGetHelp.Size = new Size(299, 20);
            LinkLblGetHelp.TabIndex = 1;
            LinkLblGetHelp.TabStop = true;
            LinkLblGetHelp.Text = "https://github.com/arkneid/VBoxVM/issues/";
            LinkLblGetHelp.LinkClicked += LinkLblGetHelp_LinkClicked;
            // 
            // LinkLabelHome
            // 
            LinkLabelHome.AutoSize = true;
            LinkLabelHome.Location = new Point(62, 69);
            LinkLabelHome.Name = "LinkLabelHome";
            LinkLabelHome.Size = new Size(283, 20);
            LinkLabelHome.TabIndex = 2;
            LinkLabelHome.TabStop = true;
            LinkLabelHome.Text = "https://sourceforge.net/projects/vboxvm/";
            LinkLabelHome.LinkClicked += LinkLabelHome_LinkClicked;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 118);
            Controls.Add(LinkLabelHome);
            Controls.Add(LinkLblGetHelp);
            Controls.Add(LblAbout);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "About";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VBoxVM";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblAbout;
        private LinkLabel LinkLblGetHelp;
        private LinkLabel LinkLabelHome;
    }
}