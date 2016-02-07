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
   public partial class Editor : Form
   {
      private string _fileName;

      public Editor()
      {
         InitializeComponent();
      }

      public void Open(string fileName)
      {
         using (var r = new System.IO.StreamReader(fileName))
         {
            txtEditor.Text=r.ReadToEnd();
            Text = System.IO.Path.GetFileName(fileName);
            _fileName = fileName;
         }

      }

      private void mnuSave_Click(object sender, EventArgs e)
      {
         using (var w = new System.IO.StreamWriter(_fileName))
         {
            w.Write(txtEditor.Text);
         }

      }
   }
}
