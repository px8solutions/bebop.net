using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Asm
{
   public class Literal:Value
   {
      public Literal(UInt value):base(value!=null?value.Size:0)
      {
         if (value == null) throw new InvalidOperationException("literals cannot have null values");
         Value = value;
      }

      public UInt Value { get; private set; }

      public override string ToString()
      {
         return "Literal: {" + Value.ToString() + "}";
      }

   }
}
