using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Asm
{
   public class Constant: Label
   {

      public Constant(string name, UInt value):base(name, value!=null?value.Size:0)
      {
         if (value==null) throw new InvalidOperationException("constants cannot have null values");
         Value = value;
      }

      public UInt Value { get; private set; }


   }
}
