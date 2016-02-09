using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBebop
{
   class Utils
   {
      public static void Debug(string msg)
      {
         System.Diagnostics.Debug.WriteLine(msg);
      }

      public static void Pause(int ms)
      {
         Application.DoEvents();
         Thread.Sleep(ms);
      }
   }
}
