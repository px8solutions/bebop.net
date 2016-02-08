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
   public partial class Output : Form, IOutput
   {


      public Output()
      {
         InitializeComponent();
      }

      public void Clear()
      {
         txtOutput.Clear();
      }

      public void Out(string message)
      {
         txtOutput.AppendText(message+"\r\n");
      }

   }
}
