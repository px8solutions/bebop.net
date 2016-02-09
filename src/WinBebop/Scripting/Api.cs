using Jurassic;
using Jurassic.Library;
using System.Windows.Forms;
using WinBebop.Core;

namespace WinBebop.Scripting
{
   public class Api:ObjectInstance
   {
      private Main _main;

      public Api(Main main, ScriptEngine scriptEngine):base(scriptEngine)
      {
         _main = main;
         this.PopulateFunctions();
      }

      [JSFunction(Name = "closeAll")]
      public void CloseAll()
      {
         _main.CloseAll();
      }

      [JSFunction(Name = "reset")]
      public void Reset()
      {
         Beboputer.Bebop.Reset();
      }


      [JSFunction(Name = "open")]
      public object Open(int window, string fileName)
      {
         Windows w = (Windows)window;

         if (fileName == "undefined") fileName = null;

         Form frm = _main.Open(w,fileName);

         switch (w)
         {
            case Windows.CPU:
               break;
            case Windows.Editor:
               return new EditorWindow((Editor)frm, Engine);
            case Windows.Output:
               return new OutputWindow((Output)frm, Engine);
            case Windows.RAM:
               return new RamWindow((MemoryWalker)frm, Engine);
         }

         return new Window(frm, Engine);

      }

   }
}
