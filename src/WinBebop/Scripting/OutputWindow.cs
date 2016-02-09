using Jurassic;
using Jurassic.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinBebop.Scripting
{
   public class OutputWindow : Window
   {
      public OutputWindow(Output frm, ScriptEngine scriptEngine) : base(frm, scriptEngine)
      {

      }

      [JSFunction(Name = "move")]
      public new void Move(int x, int y)
      {
         base.Move(x, y);
      }

      [JSFunction(Name = "resize")]
      public new void Resize(int width, int height)
      {
         base.Resize(width, height);
      }

      [JSFunction(Name = "clear")]
      public void Clear()
      {
         ((Output)_frm).Clear();
      }

      [JSFunction(Name = "out")]
      public void Out(string text)
      {
         ((Output)_frm).Out(text);
      }

   }
}
