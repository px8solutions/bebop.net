using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace CmdBop
{
    class Program
    {
        static bool _running = false;
        static byte _accumulator = 0;
        static byte _programCounter = 0;
        static byte _instructionRegister = 0;
        static byte[] _ram = new byte[65536];

        private static void Main(string[] args)
        {
            //LDA [[$0020]]
            _ram[0x00] = 0x93;
            _ram[0x01] = 0x00;
            _ram[0x02] = 0x20;

            //INCA
            _ram[0x03] = 0x80;
            _ram[0x04] = 0x80;
            _ram[0x05] = 0x80;
            _ram[0x06] = 0x80;

            //STA [[$0021]]
            _ram[0x07] = 0x9B;
            _ram[0x08] = 0x00;
            _ram[0x09] = 0x22;

            //HLT
            _ram[0x0F] = 0x01;

            //===========================================================================
            //DATA

            //contains the address of the initial place (0x30)
            _ram[0x20] = 0x00;
            _ram[0x21] = 0x30;

            //contains the address of the final place (0x31)
            _ram[0x22] = 0x00;
            _ram[0x23] = 0x31;

            //place where the initial value can be found
            _ram[0x30] = 0x24;

            //place where the final result goes    
            _ram[0x31] = 0xFF;

            while (true)
            {

                Console.WriteLine();
                Console.WriteLine();
                report();

                Console.WriteLine("------------------------------------------------------------------------------");
                Console.Write("bebop: ");

                char cmd;

                if (_running)
                {
                    Thread.Sleep(1);
                    cmd = 's';
                }
                else
                {
                    cmd = Console.ReadKey().KeyChar;
                }

                switch (cmd)
                {
                    case 'q':
                        Console.WriteLine("bye!");
                        return;

                    case '=':
                        //this don't work now
                        break;

                    case 'r':
                        _running = true;
                        break;
                    case '!':
                        _running = false;
                        _accumulator = 0;
                        _programCounter = 0;
                        _instructionRegister = 0;
                        break;
                    case 's':

                        _instructionRegister = _ram[_programCounter];

                        if (_instructionRegister == 0x00)
                        {
                            //NOP 
                            //(IMPLIED)                            
                            _programCounter += 1;
                        }
                        else if (_instructionRegister == 0x01)
                        {
                            //HLT
                            //(IMPLIED)                            
                            _running = false;
                        }
                        else if (_instructionRegister == 0x90)
                        {
                            //LDA $FF 
                            //(IMMEDIATE)
                            //load the accumulator with the value in ram with the next byte after the opcode
                            byte operand = _ram[_programCounter + 1];

                            _accumulator = operand;

                            _programCounter += 2;
                        }
                        else if (_instructionRegister == 0x91)
                        {
                            //LDA [$FFFF]
                            //(ABSOLUTE)
                            //load the accumulator with the value in ram at the location pointed to in the next two bytes after the opcode
                            byte high = _ram[_programCounter + 1];
                            byte low = _ram[_programCounter + 2];

                            //todo: this will only work for less than 255
                            _accumulator = _ram[low];

                            _programCounter += 3;
                        }
                        else if (_instructionRegister == 0x93)
                        {
                            //LDA [[$FFFF]]
                            //(INDIRECT)
                            //load the accumulator with the value in ram at the location pointed with the location pointed to.
                            byte high = _ram[_programCounter + 1];
                            byte low = _ram[_programCounter + 2];

                            byte address = low;

                            byte higher = _ram[low];
                            byte lower = _ram[low + 1];

                            _accumulator = _ram[lower];

                            _programCounter += 3;
                        }

                        else if (_instructionRegister == 0x80)
                        {
                            //INCA 
                            //(IMPLIED)
                            //increment the accumulator
                            _accumulator++;

                            _programCounter++;
                        }
                        else if (_instructionRegister == 0x99)
                        {
                            //STA [$FFFF] 
                            //(ABSOLUTE)
                            //store the value in the accumulator into ram at the location pointed to be the next two bytes after the opcode
                            byte high = _ram[_programCounter + 1];
                            byte low = _ram[_programCounter + 2];

                            //todo: this will only work for less than 255
                            _ram[low] = _accumulator;


                            _programCounter += 3;
                        }
                        else if (_instructionRegister == 0x9B)
                        {
                            //STA [[$FFFF]] 
                            //(INDIRECT)
                            //store a value in the accumulator into ram at the location pointed to by the location pointed to
                            byte high = _ram[_programCounter + 1];
                            byte low = _ram[_programCounter + 2];

                            byte address = low;

                            byte higher = _ram[low];
                            byte lower = _ram[low + 1];

                            _ram[lower] = _accumulator;

                            _programCounter += 3;
                        }
                        else
                        {
                            Console.WriteLine("unknown value or opcode at [" + _programCounter.ToString("X2") + "]");
                            quit();
                        }

                        break;

                    default:

                        Console.WriteLine("Uknown Command");
                        break;

                }
            }



        }


        public static void report()
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("\tA: [" + _accumulator.ToString("X2") + "]\t\tPC: [" + _programCounter.ToString("X2") + "]\tIR:[" + _instructionRegister.ToString("X2")+"]");
            Console.WriteLine("------------------------------------------------------------------------------");

            int a = 0;

            for (int i = 0; i < 15; ++i)
            {
                Console.Write("\t");
                
                for (int j = 0; j < 10; ++j)
                {

                    if (a == _programCounter)
                    {
                        Console.Write(" [");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                    Console.Write(_ram[a].ToString("X2"));

                    if (a == _programCounter)
                    {
                        Console.Write("] ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                    a++;
                
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            
        }

        public static void quit()
        {
            Console.WriteLine("any key to quit");
            Console.ReadKey();
            Environment.Exit(0);
        }

    }
}
