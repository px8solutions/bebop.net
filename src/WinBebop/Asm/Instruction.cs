using System;
using WinBebop.Core;

namespace WinBebop.Asm
{
   public abstract class Instruction:Statement
   {
      public Operand Operand { get; set; }

      public virtual void Execute(CPU cpu, RAM ram)
      {
         OnExecute(cpu, ram);
         cpu.IP += Size;
      }

      public virtual void OnExecute(CPU cpu, RAM ram)
      {

      }

      public virtual byte Size
      {
         get
         {
            return (byte) (1 + (Operand != null ? Operand.Value.Size : 0));
         }
      }
      
      public virtual string Mnemonic
      {
         get
         {
            MnemonicAttribute ma = (MnemonicAttribute)Attribute.GetCustomAttribute(GetType(), typeof(MnemonicAttribute));

            if (ma != null) return ma.Mnemonic;

            return GetType().Name;
         }
      }

      public virtual byte Opcode
      {
         get
         {
            OpcodeAttribute[] oas = (OpcodeAttribute[])Attribute.GetCustomAttributes(GetType(), typeof(OpcodeAttribute));

            AddressingModes am = (Operand != null ? Operand.AddressingMode : AddressingModes.Implied);

            foreach (OpcodeAttribute oa in oas)
            {
               if (oa.AddressingMode==am)
               {
                  return oa.Opcode;
               }
            }

            throw new InvalidOperationException("Instruction {"+Mnemonic+"} has no opcode defined for this addressing mode {"+ Enum.GetName(typeof(AddressingModes), am) + "}");
         }
      }

      public static string GetOpcodeKey(string mnemonic, AddressingModes addressingMode)
      {
         return mnemonic + "_" + Enum.GetName(typeof(AddressingModes), addressingMode);
      }

      public AddressingModes AddressingMode
      {
         get
         {
            return Operand != null ? Operand.AddressingMode : AddressingModes.Implied;
         }
      }

      public override string ToString()
      {
         string opcode = "???";

         if (Beboputer.Opcodes.ContainsKey(GetOpcodeKey(Mnemonic,AddressingMode)))
         {
            opcode = string.Format("${0:X02}", Beboputer.Opcodes[GetOpcodeKey(Mnemonic, AddressingMode)]);
         }

         return (Label != null ? Label + ": " : "") + Mnemonic +" ("+opcode+")" + (Operand != null ? ": {" + Operand.ToString() + "}" : "") + (Comment != null ? " # " + Comment : "");
      }

   }
}
