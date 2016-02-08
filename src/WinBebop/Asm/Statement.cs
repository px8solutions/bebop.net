using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Asm
{
   public abstract class Statement:Line
   {
      public string Label { get; set; }
      public string Comment { get; set; }

   }
}
