using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Asm
{
   public class Pointer:Label
   {

      public Pointer (string name):base(name,2)
      {
      }

      public ushort Read()
      {

         //todo read the value from RAM
         throw new NotImplementedException("TODO");
      }

      public override string ToString()
      {
         return "Pointer: {TODO}";
      }

   }
}
