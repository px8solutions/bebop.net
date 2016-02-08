using WinBebop.Core;
using WinBebop.Asm;

namespace WinBebop.ISA
{
   [Opcode(0x90,AddressingModes.Immediate)]
   [Opcode(0x91, AddressingModes.Absolute)]
   [Opcode(0x92, AddressingModes.Indexed)]
   [Opcode(0x93, AddressingModes.Indirect)]
   [Opcode(0x94, AddressingModes.IndirectPreIndexed)]
   [Opcode(0x95, AddressingModes.IndirectPostIndexed)]
   public class LDA: Instruction
   {
   }
}
