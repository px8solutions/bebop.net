using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinBebop.Asm;

namespace WinBebop.ISA
{
   [Opcode(0, AddressingModes.Implied)]
   public class NOP:Instruction
   {
   }
}
