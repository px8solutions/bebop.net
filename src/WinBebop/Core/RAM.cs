using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Core
{
   public class RAM
   {
      private byte[] _ram = new byte[ushort.MaxValue];

      public void Reset()
      {
         _ram = new byte[ushort.MaxValue];
      }

   }
}
