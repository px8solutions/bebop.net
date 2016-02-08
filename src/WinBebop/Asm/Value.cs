using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Asm
{
   public abstract class Value
   {
      public Value(int size)
      {
         Size = size;
      }

      public int Size { get; private set; }


   }
}
