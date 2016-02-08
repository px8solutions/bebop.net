using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Asm
{
   public abstract class Directive : Statement
   {

      public UInt Value { get; set; }

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
         return (Label!=null?Label+": ":"")+"."+Mnemonic+(Value!= null?": {" + Value.ToString() + "}":"")+ (Comment != null ? " # "+Comment : "");
      }

   }
}
