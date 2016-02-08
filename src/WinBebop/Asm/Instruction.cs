using System;
using WinBebop.Core;

namespace WinBebop.Asm
{
   public abstract class Instruction
   {

      protected Instruction(Operand operand)
      {
         Operand = operand;
      }

      public virtual void Execute(CPU cpu, RAM ram)
      {
         OnExecute(cpu, ram);
         cpu.IP += Size;
      }

      public virtual void OnExecute(CPU cpu, RAM ram)
      {

      }

      public Operand Operand { get; private set; }

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
       
   }
}
