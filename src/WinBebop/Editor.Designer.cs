namespace WinBebop
{
   partial class Editor
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
         this.txtEditor = new System.Windows.Forms.TextBox();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.tsbAssemble = new System.Windows.Forms.ToolStripButton();
         this.menuStrip1.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // txtEditor
         // 
         this.txtEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtEditor.Location = new System.Drawing.Point(0, 28);
         this.txtEditor.Multiline = true;
         this.txtEditor.Name = "txtEditor";
         this.txtEditor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.txtEditor.Size = new System.Drawing.Size(258, 216);
         this.txtEditor.TabIndex = 0;
         this.txtEditor.WordWrap = false;
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(331, 24);
         this.menuStrip1.TabIndex = 1;
         this.menuStrip1.Text = "menuStrip1";
         this.menuStrip1.Visible = false;
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSave});
         this.fileToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "&File";
         // 
         // mnuSave
         // 
         this.mnuSave.Name = "mnuSave";
         this.mnuSave.Size = new System.Drawing.Size(98, 22);
         this.mnuSave.Text = "&Save";
         this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAssemble});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(258, 25);
         this.toolStrip1.TabIndex = 2;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // tsbAssemble
         // 
         this.tsbAssemble.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this.tsbAssemble.Image = ((System.Drawing.Image)(resources.GetObject("tsbAssemble.Image")));
         this.tsbAssemble.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.tsbAssemble.Name = "tsbAssemble";
         this.tsbAssemble.Size = new System.Drawing.Size(62, 22);
         this.tsbAssemble.Text = "Assemble";
         this.tsbAssemble.Click += new System.EventHandler(this.tsbAssemble_Click);
         // 
         // Editor
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(258, 244);
         this.Controls.Add(this.txtEditor);
         this.Controls.Add(this.toolStrip1);
         this.Controls.Add(this.menuStrip1);
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "Editor";
         this.Text = "Editor";
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox txtEditor;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem mnuSave;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton tsbAssemble;
   }
}