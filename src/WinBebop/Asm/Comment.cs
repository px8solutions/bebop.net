using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Asm
{
   public class Comment:Line
   {
      public override string ToString()
      {
         return "Comment: {" + Text + "}";
      }

   }
}
