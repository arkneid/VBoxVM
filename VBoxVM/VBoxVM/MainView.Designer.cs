namespace VBoxVM
{
    partial class MainView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            label1 = new Label();
            txt_folder_path = new TextBox();
            btn_choose_folder = new Button();
            btn_change = new Button();
            main_label = new Label();
            ntfIconMain = new NotifyIcon(components);
            MainMenu = new MenuStrip();
            hElpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            MainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 57);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 0;
            label1.Text = "VBox Folder:";
            // 
            // txt_folder_path
            // 
            txt_folder_path.BackColor = SystemColors.HighlightText;
            txt_folder_path.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_folder_path.Location = new Point(12, 81);
            txt_folder_path.Margin = new Padding(3, 4, 3, 4);
            txt_folder_path.Name = "txt_folder_path";
            txt_folder_path.Size = new Size(454, 27);
            txt_folder_path.TabIndex = 1;
            // 
            // btn_choose_folder
            // 
            btn_choose_folder.Location = new Point(249, 115);
            btn_choose_folder.Name = "btn_choose_folder";
            btn_choose_folder.Size = new Size(141, 50);
            btn_choose_folder.TabIndex = 2;
            btn_choose_folder.Text = "Choose Folder";
            btn_choose_folder.UseVisualStyleBackColor = true;
            btn_choose_folder.Click += button1_Click;
            // 
            // btn_change
            // 
            btn_change.Location = new Point(93, 115);
            btn_change.Name = "btn_change";
            btn_change.Size = new Size(141, 50);
            btn_change.TabIndex = 3;
            btn_change.Text = "Change";
            btn_change.UseVisualStyleBackColor = true;
            btn_change.Click += btn_change_Click;
            // 
            // main_label
            // 
            main_label.Dock = DockStyle.Top;
            main_label.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            main_label.Location = new Point(0, 24);
            main_label.Name = "main_label";
            main_label.Size = new Size(478, 53);
            main_label.TabIndex = 4;
            main_label.Text = "VBox default folder";
            main_label.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ntfIconMain
            // 
            ntfIconMain.Icon = (Icon)resources.GetObject("ntfIconMain.Icon");
            ntfIconMain.Text = "VBoxVM";
            ntfIconMain.Visible = true;
            ntfIconMain.MouseClick += notifyIcon_MouseClick;
            // 
            // MainMenu
            // 
            MainMenu.Items.AddRange(new ToolStripItem[] { hElpToolStripMenuItem });
            MainMenu.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.RenderMode = ToolStripRenderMode.Professional;
            MainMenu.Size = new Size(478, 24);
            MainMenu.TabIndex = 5;
            MainMenu.Text = "MainMenu";
            // 
            // hElpToolStripMenuItem
            // 
            hElpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            hElpToolStripMenuItem.Name = "hElpToolStripMenuItem";
            hElpToolStripMenuItem.Size = new Size(44, 20);
            hElpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(107, 22);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(478, 177);
            Controls.Add(main_label);
            Controls.Add(btn_change);
            Controls.Add(btn_choose_folder);
            Controls.Add(txt_folder_path);
            Controls.Add(label1);
            Controls.Add(MainMenu);
            Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MainMenu;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VBoxVM";
            Resize += onResizeMain;
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txt_folder_path;
        private Button btn_choose_folder;
        private Button btn_change;
        private Label main_label;
        private NotifyIcon ntfIconMain;
        private MenuStrip MainMenu;
        private ToolStripMenuItem hElpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
    }
}
