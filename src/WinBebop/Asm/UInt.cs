using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Asm
{
   public abstract class UInt
   {
      

      public UInt(int size)
      {
         Size = size;
      }

      public int Size { get; private set; }

      public static UInt Parse(string text)
      {
         //($ff | 255 | %10101010) | ($ffff | 64000 | %1010101010101010

         if (text != null)
         {
            if (char.IsDigit(text[0]))
            {
               ushort value = Convert.ToUInt16(text, 10);

               if (value <= 255)
               {
                  return new U8((byte)value);
               }
               else if (value <= 65535)
               {
                  return new U16(value);
               }
               else
               {
                  throw new InvalidOperationException("decimal too large {" + text + "}");
               }

            }
            else if (text[0] == '$')
            {
               if (text.Length == 3)
               {
                  return new U8(Convert.ToByte(text.Substring(1,text.Length-1), 16));
               }
               else if (text.Length == 5)
               {
                  return new U16(Convert.ToUInt16(text.Substring(1, text.Length - 1), 16));
               }
               else
               {
                  throw new InvalidOperationException("invalid hex string {" + text + "}");
               }
            }
            else if (text[0] == '%')
            {
               if (text.Length == 9)
               {
                  return new U8(Convert.ToByte(text.Substring(1, text.Length - 1), 2));
               }
               else if (text.Length == 17)
               {
                  return new U16(Convert.ToUInt16(text.Substring(1, text.Length - 1), 2));
               }
               else
               {
                  throw new InvalidOperationException("invalid binary string {" + text + "}");
               }

            }
         }


         return null;
      }


   }
}
