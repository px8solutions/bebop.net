using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Asm
{
   [Flags]
   public enum AddressingModes
   {
      Implied=0,                 //
      Immediate=1,               //$ff
      BigImmediate=2,            //$ffff
      Absolute=4,                //[$ffff]
      Indexed=8,                 //[$ffff,X]
      Indirect = 16,             //[[$ffff]]
      IndirectPreIndexed = 32,   //[[$ffff,X]]
      IndirectPostIndexed=64     //[[$ffff],X]
   }
}
