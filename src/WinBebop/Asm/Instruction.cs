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

      public override string ToString()
      {
         return (Label != null ? Label + ": " : "") + "." + Mnemonic + (Operand != null ? ": {" + Operand.ToString() + "}" : "") + (Comment != null ? " # " + Comment : "");
      }

   }
}
