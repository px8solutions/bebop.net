﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Asm
{
   public class U8:UInt
   {
      private byte _value;

      public U8(byte value):base(1)
      {
         _value = value;
      }

      public byte Read()
      {
         return _value;
      }

      public override string ToString()
      {
         return "U8: {" + string.Format("${0:X02}",_value) + "}";
      }

   }
}
