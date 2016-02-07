using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Core
{
   public class Operand
   {
      private byte _size;
      private ushort _value;

      public Operand(AddressingModes addressingMode)
      {
         //implied
         _size = 0;
      }

      public Operand (AddressingModes addressingMode, byte value)
      {
         //immediate
         _size = 1;
         _value = value;
      }

      public Operand(AddressingModes addressingMode, ushort value)
      {
         _size = 2;
         _value = value;
      }

      public byte Size
      {
         get
         {
            return _size;
         }
      }

      public static Operand Parse(string text)
      {


         //v
         //[v]
         //[[v]]
         //[v,X]
         //[[v,X]]
         //[[v],X]





         return null;
      }

   }
}
