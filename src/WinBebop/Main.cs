using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBebop
{
   public partial class Main : Form
   {
      private Output _frmOutput = new Output();

      public Main()
      {
         InitializeComponent();

         var frm = new Editor();
         frm.MdiParent = this;
         frm.Open(System.IO.Directory.GetCurrentDirectory()+"\\Test.asm");
         frm.Show();

         _frmOutput.MdiParent = this;
         _frmOutput.StartPosition = FormStartPosition.Manual;
         _frmOutput.Show();
         _frmOutput.Location = new Point(400, 50);

         ISA.LDA lda = new ISA.LDA();
         Text = lda.Mnemonic;
      }

      private void tsbRAM_Click(object sender, EventArgs e)
      {
         var frm = new MemoryWalker();
         frm.MdiParent = this;
         frm.Show();
      }

      private void mnuNew_Click(object sender, EventArgs e)
      {
         var frm = new Editor();
         frm.MdiParent = this;
         frm.Show();

      }

      private void mnuOpen_Click(object sender, EventArgs e)
      {
         OpenFileDialog openFileDialog1 = new OpenFileDialog();
         openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
         openFileDialog1.Filter = "Bebop Assembly Files|*.asm";
         openFileDialog1.Title = "Select an Assembly File";

         if (openFileDialog1.ShowDialog() == DialogResult.OK)
         {
            var frm = new Editor();
            frm.MdiParent = this;
            frm.Open(openFileDialog1.FileName);


            frm.Show();

         }
      }

      public Output Output
      {
         get
         {
            return _frmOutput;
         }
      }

      private void tsbOutput_Click(object sender, EventArgs e)
      {
         if (_frmOutput.Visible)
         {
            _frmOutput.Hide();
         }
         else
         {
            _frmOutput.Show();
         }
      }
   }
}
