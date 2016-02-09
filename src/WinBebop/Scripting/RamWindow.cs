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
   public class RamWindow : Window
   {
      public RamWindow(MemoryWalker frm, ScriptEngine scriptEngine) : base(frm, scriptEngine)
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

      [JSFunction(Name = "scrollTo")]
      public void ScrollTo(int address)
      {
         ((MemoryWalker)_frm).ScrollTo(address);
      }

   }
}
