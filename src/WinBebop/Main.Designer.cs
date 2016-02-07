namespace WinBebop
{
   partial class Main
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
         this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
         this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.tsbRAM = new System.Windows.Forms.ToolStripButton();
         this.menuStrip1.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(688, 24);
         this.menuStrip1.TabIndex = 1;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // mnuFile
         // 
         this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuOpen});
         this.mnuFile.Name = "mnuFile";
         this.mnuFile.Size = new System.Drawing.Size(37, 20);
         this.mnuFile.Text = "&File";
         // 
         // mnuNew
         // 
         this.mnuNew.Name = "mnuNew";
         this.mnuNew.Size = new System.Drawing.Size(152, 22);
         this.mnuNew.Text = "&New";
         this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
         // 
         // mnuOpen
         // 
         this.mnuOpen.Name = "mnuOpen";
         this.mnuOpen.Size = new System.Drawing.Size(152, 22);
         this.mnuOpen.Text = "&Open";
         this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRAM});
         this.toolStrip1.Location = new System.Drawing.Point(0, 24);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(688, 25);
         this.toolStrip1.TabIndex = 2;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // tsbRAM
         // 
         this.tsbRAM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.tsbRAM.Image = ((System.Drawing.Image)(resources.GetObject("tsbRAM.Image")));
         this.tsbRAM.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tsbRAM.Name = "tsbRAM";
         this.tsbRAM.Size = new System.Drawing.Size(37, 22);
         this.tsbRAM.Text = "RAM";
         this.tsbRAM.Click += new System.EventHandler(this.tsbRAM_Click);
         // 
         // Beboputer
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(688, 438);
         this.Controls.Add(this.toolStrip1);
         this.Controls.Add(this.menuStrip1);
         this.IsMdiContainer = true;
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "Beboputer";
         this.Text = "Beboputer";
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem mnuFile;
      private System.Windows.Forms.ToolStripMenuItem mnuNew;
      private System.Windows.Forms.ToolStripMenuItem mnuOpen;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton tsbRAM;
   }
}