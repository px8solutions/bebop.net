using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Asm
{
   public interface IOutput
   {
      void Clear();
      void Out(string message);
   }
}
