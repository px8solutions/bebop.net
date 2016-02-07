using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Core
{
   [AttributeUsage(validOn: AttributeTargets.Class)]
   public class MnemonicAttribute:Attribute
   {
      public string Mnemonic { get; private set; }

      public MnemonicAttribute(string mnemonic)
      {
         Mnemonic = mnemonic;
      }

   }
}
