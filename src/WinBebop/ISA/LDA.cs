using WinBebop.Core;

namespace WinBebop.ISA
{
   [Opcode(0x91,AddressingModes.Immediate)]
   [Opcode(0x92, AddressingModes.BigImmediate)]
   public class LDA: Instruction
   {
      public LDA():base(null)
      {

      }
   }
}
