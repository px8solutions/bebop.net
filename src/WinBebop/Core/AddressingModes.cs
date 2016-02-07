using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Core
{
   [Flags]
   public enum AddressingModes
   {
      Implied=0,
      Immediate=1,
      BigImmediate=2,
      Absolute=4,
      Indexed=8,
      Indirect = 16,
      IndirectPreIndexed = 32,
      IndirectPostIndexed=64
   }
}
