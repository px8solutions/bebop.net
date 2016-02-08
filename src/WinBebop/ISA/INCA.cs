using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinBebop.Asm;

namespace WinBebop.ISA
{
   [Opcode(0x80,AddressingModes.Implied)]
   public class INCA:Instruction
   {
   }
}
