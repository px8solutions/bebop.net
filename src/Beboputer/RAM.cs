using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beboputer
{
    public class RAM
    {
        private byte[] _ram = new byte[65536];


        public byte this[int address]
        {
            get
            {
                return Read(address);
            }
            set
            {
                Write(address,value);
            }
        }

        public byte Read(int address)
        {
            return _ram[address];
        }

        public byte Read(byte low, byte high)
        {
            return _ram[To16(low,high)];
        }

        public byte ReadIndirect(int low, int high)
        {
            byte h = this[To16(low,high) + 1];
            byte l = this[To16(low,high) + 2];

            byte h2 = Read(l, h);
            byte l2 = this[RAM.To16(l, h) + 1];



            return _ram[To16(l2, h2)];
        }



        public void Write(int address, byte data)
        {
            _ram[address]=data;
        }

        public void Write(byte low, byte high, byte data)
        {
            _ram[To16(low,high)] = data;
        }

        public static int To16(int low, int high)
        {
            return (high << 8) + low;
        }

    }
}
