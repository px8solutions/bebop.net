using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Core
{
   public class Value
   {
      private ushort _value;

      public Value(ushort value)
      {
         _value = value;
      }

      public static Value Parse(string text)
      {
         //v=LABEL

         //v=$ff
         //v=255
         //v=%10101010

         //v=$ffff
         //v=64000
         //v=%1010101010101010
         return null;
      }

   }
}
