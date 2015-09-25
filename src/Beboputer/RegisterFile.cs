using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Beboputer
{
    public class RegisterFile
    {
        private byte _accumulator = 0;
        private byte _programCounter = 0;
        private byte _instructionRegister = 0;

        public void Reset()
        {
            _accumulator = 0;
            _programCounter = 0;
            _instructionRegister = 0;
        }

        public byte IR
        {
            set { _instructionRegister=value; }
            get { return _instructionRegister; }
        }

        public byte PC
        {
            set { _programCounter = value; }
            get { return _programCounter; }
        }

        public byte A
        {
            set { _accumulator = value; }
            get { return _accumulator; }
        }

    }
}
