using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinBebop.Asm;
using WinBebop.Core;

namespace WinBebop
{
   public partial class Editor : Form
   {
      private string _fileName;
      private string _extension;

      public Editor(string extension="")
      {
         InitializeComponent();
         Extension = extension;
      }

      private string Extension
      {
         get
         {
            return _extension;
         }

         set
         {
            _extension = value;

            tsbAssemble.Visible = false;
            tsbExecute.Visible = false;

            if (_extension == ".asm")
            {
               tsbAssemble.Visible = true;
            }
            else if (_extension == ".js")
            {
               tsbExecute.Visible = true;
            }

         }
      }


      public void Open(string fileName)
      {
         using (var r = new System.IO.StreamReader(fileName))
         {
            txtEditor.Text=r.ReadToEnd();
            Text = System.IO.Path.GetFileName(fileName);
            _fileName = fileName;

            Extension = System.IO.Path.GetExtension(_fileName);
         }

      }

      private void mnuSave_Click(object sender, EventArgs e)
      {
         using (var w = new System.IO.StreamWriter(_fileName))
         {
            w.Write(txtEditor.Text);
         }

      }

      private void tsbAssemble_Click(object sender, EventArgs e)
      {
         Assemble();
      }

      public void Assemble()
      {
         ((Main)MdiParent).Output.Clear();

         Beboputer.Bebop.Reset();

         Assembler.Assemble(txtEditor.Lines, ((Main)MdiParent).Output);
      }

      private void tsbExecute_Click(object sender, EventArgs e)
      {
         try
         {
            ((Main)MdiParent).JsEngine.Execute(txtEditor.Text);
         }
         catch(Exception ex)
         {
            MessageBox.Show(ex.Message);
         }
      }
   }
}
