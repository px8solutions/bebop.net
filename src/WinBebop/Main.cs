using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBebop.Scripting;

namespace WinBebop
{
   public partial class Main : Form
   {
      private Output _frmOutput = new Output();

      private JsEngine _jsEngine;

      public Main()
      {
         InitializeComponent();


         _frmOutput.MdiParent = this;
         _frmOutput.StartPosition = FormStartPosition.Manual;

         //var frm = new Editor();
         //frm.MdiParent = this;
         ////frm.Open(System.IO.Directory.GetCurrentDirectory()+"\\Test.asm");
         //frm.Open("Test.asm");
         //frm.Show();

         //var frm2 = new Editor();
         //frm2.MdiParent = this;
         //frm2.Open(System.IO.Directory.GetCurrentDirectory() + "\\Test.js");
         //frm2.Show();

         _jsEngine = new JsEngine(this);
      }


      public JsEngine JsEngine
      {
         get
         {
            return _jsEngine;
         }
      }

      private void Main_Load(object sender, EventArgs e)
      {
      }

      private void Main_Shown(object sender, EventArgs e)
      {
         _jsEngine.ExecuteFile("Scripts/Init.js");
      }

      private void tsbRAM_Click(object sender, EventArgs e)
      {
         Open(Windows.RAM);
      }

      public Form Open(Windows window, string fileName=null)
      {
         Form frm=null;

         switch (window)
         {
            case Windows.CPU:
               break;
            case Windows.Editor:
               frm = new Editor();
               ((Editor)frm).Open(fileName);
               break;
            case Windows.Output:
               _frmOutput.Show();
               return _frmOutput;
            case Windows.RAM:
               frm = new MemoryWalker();
               break;
            default:
               break;
         }

         if (frm!=null)
         {
            frm.MdiParent = this;
            frm.Show();
         }

         return frm;
      }

      private void mnuNewListing_Click(object sender, EventArgs e)
      {
         var frm = new Editor(".asm");
         frm.MdiParent = this;
         frm.Show();
      }

      private void mnuNewScript_Click(object sender, EventArgs e)
      {
         var frm = new Editor(".js");
         frm.MdiParent = this;
         frm.Show();
      }


      private void mnuOpen_Click(object sender, EventArgs e)
      {
         OpenFileDialog openFileDialog1 = new OpenFileDialog();
         openFileDialog1.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
         openFileDialog1.Filter = "Bebop Assembly Files|*.asm|JavaScript Files|*.js";
         openFileDialog1.Title = "Select an Assembly File";

         if (openFileDialog1.ShowDialog() == DialogResult.OK)
         {
            var frm = new Editor();
            frm.MdiParent = this;
            frm.Open(openFileDialog1.FileName);


            frm.Show();

         }
      }

      public void CloseAll()
      {
         foreach (Form frm in MdiChildren)
         {
            if (frm is Output)
            {
               frm.Hide();
            }
            else
            {
               frm.Close();
            }
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

      private void mnuCloseAll_Click(object sender, EventArgs e)
      {
         CloseAll();
      }

   }
}
