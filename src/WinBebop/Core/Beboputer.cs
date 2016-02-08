using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinBebop.Asm;

namespace WinBebop.Core
{
   public class Beboputer
   {

      public static Beboputer Bebop { get; private set; } = new Beboputer();

      public static Dictionary<string, Type> Directives { get; private set; } = new Dictionary<string, Type>();
      public static Dictionary<string, Type> Instructions { get; private set; } = new Dictionary<string, Type>();
      public static Dictionary<string, byte> Opcodes { get; private set; } = new Dictionary<string, byte>();

      public List<Line> Lines { get; private set; } = new List<Line>();
      public Dictionary<string, Label> Labels { get; private set; } = new Dictionary<string, Label>();
      public Dictionary<string, Constant> Constants { get; private set; } = new Dictionary<string, Constant>();
      public Dictionary<string, Pointer> Pointers { get; private set; } = new Dictionary<string, Pointer>();

      public CPU CPU { get; private set; } = new CPU();
      public RAM RAM { get; private set; } = new RAM();


       static Beboputer()
      {
         //find instructions and directives
         Directives.Add("ORG", typeof(WinBebop.Directives.ORG));
         Directives.Add("END", typeof(WinBebop.Directives.END));

         Instructions.Add("NOP", typeof(WinBebop.ISA.NOP));
         Instructions.Add("LDA", typeof(WinBebop.ISA.LDA));

      }

      public void Reset()
      {
         Stop();
         CPU.Reset();
         RAM.Reset();
         Lines.Clear();
         Labels.Clear();
         Constants.Clear();
         Pointers.Clear();
      }

      public void Stop()
      {

      }

   }
}
