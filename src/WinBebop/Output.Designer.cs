namespace WinBebop
{
   partial class Output
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
         this.txtOutput = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // txtOutput
         // 
         this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.txtOutput.Location = new System.Drawing.Point(1, 1);
         this.txtOutput.Multiline = true;
         this.txtOutput.Name = "txtOutput";
         this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.txtOutput.Size = new System.Drawing.Size(404, 281);
         this.txtOutput.TabIndex = 0;
         this.txtOutput.WordWrap = false;
         // 
         // Output
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(405, 283);
         this.Controls.Add(this.txtOutput);
         this.Name = "Output";
         this.Text = "Output";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox txtOutput;
   }
}