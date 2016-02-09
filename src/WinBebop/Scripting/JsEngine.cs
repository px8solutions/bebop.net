using Jurassic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WinBebop.Scripting
{
   public class JsEngine
   {
      private ScriptEngine _scriptEngine;


      public JsEngine(Main main)
      {
         _scriptEngine = new ScriptEngine();
         _scriptEngine.SetGlobalFunction("Pause", new Action<int>(Utils.Pause));
         _scriptEngine.SetGlobalValue("Bebop", new Api(main,_scriptEngine));

         _scriptEngine.SetGlobalValue("console", new Jurassic.Library.FirebugConsole(_scriptEngine));


         
         //_scriptEngine.EnableDebugging = true;
         //_scriptEngine.ExecuteFile("Test.js");

         string windows = "";
         foreach (Windows w in Enum.GetValues(typeof(Windows)))
         {
            if (windows != "") windows += ",";
            windows += Enum.GetName(typeof(Windows), w) + " : " + (int)w;
         }

         _scriptEngine.Execute("var Windows={ " + windows + " };");

      }

      public void Execute(string js)
      {
         _scriptEngine.Execute(js);
      }

      public void ExecuteFile(string fileName)
      {
         _scriptEngine.ExecuteFile(fileName);
      }
   }
}
