using System;
using Jurassic;
using Jurassic.Library;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;

namespace WinBebop.Scripting
{
   public class Window : ObjectInstance
   {
      protected Form _frm;

      public Window(Form frm, ScriptEngine scriptEngine) : base(scriptEngine)
      {
         _frm = frm;

         this.PopulateFunctions();
      }

      [JSFunction(Name = "move")]
      public void Move(int x, int y)
      {
         _frm.Location = new Point(x, y);
      }

      [JSFunction(Name = "resize")]
      public void Resize(int width, int height)
      {
         _frm.Size = new Size(width, height);
      }

   }
}
