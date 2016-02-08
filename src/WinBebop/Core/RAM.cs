using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Core
{
   public class RAM
   {
      private ushort[] _ram = new ushort[ushort.MaxValue];

      public void Reset()
      {
         Array.Clear(_ram,0,_ram.Length);
      }

      public void Write(ushort address, byte value)
      {
         _ram[address] = (ushort)(0x0000FF00|value);
      }

      public bool HasValue(ushort address)
      {
         return (_ram[address] & 0xFF00) == 0xFF00;
      }

      public byte Read(ushort address)
      {
         return (byte)(_ram[address] & 0x000000FF);
      }

   }
}
