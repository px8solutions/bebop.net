using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CmdBop
{
    class Program
    {
        static byte accumulator = 0;
        static byte programCounter = 0;
        static byte instructionRegister = 0;
        static byte[] ram = new byte[65536];

        static void Main(string[] args)
        {
            //LDA $0020
            ram[0x00] = 0x91;
            ram[0x01] = 0x00;
            ram[0x02] = 0x20;

            //INCA
            ram[0x03] = 0x80;
            ram[0x04] = 0x80;
            ram[0x05] = 0x80;
            ram[0x06] = 0x80;

            //STA $0030
            ram[0x07] = 0x99;
            ram[0x08] = 0x00;
            ram[0x09] = 0x30;

            //data
            ram[0x20] = 0x24;
            ram[0x30] = 0xFF;

            while (true)
            {

                Console.WriteLine();
                Console.WriteLine();
                report();

                Console.WriteLine("------------------------------------------------------------------------------");
                Console.Write("bebop: ");

                string cmd=Console.ReadLine();

                if (cmd != null)
                {
                    string[] parts = cmd.Split(' ');

                    if (parts[0] == "quit")
                    {
                        Console.WriteLine("bye!");
                        return;
                    }
                    else if (parts[0] == "set")
                    {
                        ram[int.Parse(parts[1])] = byte.Parse(parts[2]);
                    }
                    else if (parts[0] == "step")
                    {
                        instructionRegister = ram[programCounter];

                        if (instructionRegister == 0x91)
                        {
                            byte high = ram[programCounter + 1];
                            byte low = ram[programCounter + 2];

                            //todo: this will only work for less than 255
                            accumulator = ram[low];

                            programCounter += 3;
                        }
                        else if (instructionRegister == 0x80)
                        {
                            accumulator++;

                            programCounter++;
                        }
                        else if (instructionRegister == 0x99)
                        {
                            byte high = ram[programCounter + 1];
                            byte low = ram[programCounter + 2];

                            //todo: this will only work for less than 255
                            ram[low] = accumulator;


                            programCounter += 3;
                        }
                        else
                        {
                            Console.WriteLine("unknown value or opcode at [" + programCounter.ToString("X2") + "]");
                            quit();
                        }


                    }
                    else
                    {
                        Console.WriteLine("Uknown Command");
                    }
                
                }

            }



        }


        public static void report()
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("A:\t" + accumulator.ToString("X2") + "\tPC:\t" + programCounter.ToString("X2") + "\tIR:\t" + instructionRegister.ToString("X2"));

            int a = 0;
            for (int i = 0; i < 15; ++i)
            {
                Console.Write("\t\t\t\t\t\t");
                for (int j = 0; j < 10; ++j)
                {
                    Console.Write(ram[a].ToString("X2") + " ");
                    a++;
                }
                Console.WriteLine();
            }
            
        }

        public static void quit()
        {
            Console.WriteLine("any key to quit");
            Console.ReadKey();
            Environment.Exit(0);
        }

    }
}
