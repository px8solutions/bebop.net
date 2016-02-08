using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Asm
{
   public abstract class Label:Value
   {

      public Label (string name, int size):base(size)
      {
         if (name == null) throw new InvalidOperationException("label name cannot be null");

         Name = name;
      }

      public string Name { get; private set; }


   }
}
