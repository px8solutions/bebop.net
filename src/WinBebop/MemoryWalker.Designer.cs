namespace WinBebop
{
   partial class MemoryWalker
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoryWalker));
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
         this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
         this.panel1 = new System.Windows.Forms.Panel();
         this.toolStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(389, 25);
         this.toolStrip1.TabIndex = 0;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // toolStripButton1
         // 
         this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
         this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton1.Name = "toolStripButton1";
         this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
         this.toolStripButton1.Text = "toolStripButton1";
         // 
         // vScrollBar1
         // 
         this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
         this.vScrollBar1.Location = new System.Drawing.Point(372, 25);
         this.vScrollBar1.Name = "vScrollBar1";
         this.vScrollBar1.Size = new System.Drawing.Size(17, 242);
         this.vScrollBar1.TabIndex = 2;
         this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
         // 
         // panel1
         // 
         this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.panel1.Location = new System.Drawing.Point(0, 25);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(372, 242);
         this.panel1.TabIndex = 3;
         this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
         this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
         // 
         // MemoryWalker
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(389, 267);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.vScrollBar1);
         this.Controls.Add(this.toolStrip1);
         this.Name = "MemoryWalker";
         this.Text = "MemoryWalker";
         this.Load += new System.EventHandler(this.MemoryWalker_Load);
         this.Resize += new System.EventHandler(this.MemoryWalker_Resize);
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton toolStripButton1;
      private System.Windows.Forms.VScrollBar vScrollBar1;
      private System.Windows.Forms.Panel panel1;
   }
}