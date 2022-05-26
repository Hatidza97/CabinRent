namespace CabinRent.WinUI
{
    partial class MainPage
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.viewAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Tan;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.viewMenu,
            this.toolsMenu,
            this.windowsMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1069, 30);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(64, 24);
            this.fileMenu.Text = "Home";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(71, 6);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAllToolStripMenuItem,
            this.newUserToolStripMenuItem});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(58, 24);
            this.editMenu.Text = "&Users";
            // 
            // viewAllToolStripMenuItem
            // 
            this.viewAllToolStripMenuItem.Name = "viewAllToolStripMenuItem";
            this.viewAllToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.viewAllToolStripMenuItem.Text = "View all";
            this.viewAllToolStripMenuItem.Click += new System.EventHandler(this.viewAllToolStripMenuItem_Click);
            // 
            // newUserToolStripMenuItem
            // 
            this.newUserToolStripMenuItem.Name = "newUserToolStripMenuItem";
            this.newUserToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.newUserToolStripMenuItem.Text = "New user";
            this.newUserToolStripMenuItem.Click += new System.EventHandler(this.newUserToolStripMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAllToolStripMenuItem1});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(90, 24);
            this.viewMenu.Text = "&Properties";
            // 
            // toolsMenu
            // 
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(70, 24);
            this.toolsMenu.Text = "&Rented";
            // 
            // windowsMenu
            // 
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(82, 24);
            this.windowsMenu.Text = "&About us";
            // 
            // helpMenu
            // 
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(74, 24);
            this.helpMenu.Text = "&Reports";
            this.helpMenu.Click += new System.EventHandler(this.helpMenu_Click);
            // 
            // viewAllToolStripMenuItem1
            // 
            this.viewAllToolStripMenuItem1.Name = "viewAllToolStripMenuItem1";
            this.viewAllToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.viewAllToolStripMenuItem1.Text = "View all";
            this.viewAllToolStripMenuItem1.Click += new System.EventHandler(this.viewAllToolStripMenuItem1_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1069, 697);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainPage";
            this.Text = "MainPage";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripMenuItem fileMenu;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem viewAllToolStripMenuItem;
        private ToolStripMenuItem newUserToolStripMenuItem;
        private ToolStripMenuItem viewAllToolStripMenuItem1;
    }
}



