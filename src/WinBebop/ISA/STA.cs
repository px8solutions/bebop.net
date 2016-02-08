using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinBebop.Asm;

namespace WinBebop.ISA
{
   [Opcode(0x99,AddressingModes.Absolute)]
   [Opcode(0x9A, AddressingModes.Indexed)]
   [Opcode(0x9B, AddressingModes.Indirect)]
   [Opcode(0x9C, AddressingModes.IndirectPreIndexed)]
   [Opcode(0x9D, AddressingModes.IndirectPostIndexed)]
   public class STA:Instruction
   {
   }
}
