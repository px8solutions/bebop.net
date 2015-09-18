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
        static bool running = false;
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

            //STA [$0021]
            ram[0x07] = 0x9B;
            ram[0x08] = 0x00;
            ram[0x09] = 0x30;

            //HLT
            ram[0x0F] = 0x01;


            //data

            //contains data to be loaded into accumulator
            ram[0x20] = 0x24; 

            //contains the address of the final place (0x30)
            ram[0x21] = 0x00;
            ram[0x22] = 0x30;

            //place where the final result goes    
            ram[0x30] = 0x00;
            ram[0x31] = 0x38; 

            while (true)
            {

                Console.WriteLine();
                Console.WriteLine();
                report();

                Console.WriteLine("------------------------------------------------------------------------------");
                Console.Write("bebop: ");

                string cmd = null;

                if (running)
                {
                    Thread.Sleep(1);
                    cmd = "s";
                }
                else
                {
                    cmd = Console.ReadLine();
                }

                if (cmd != null)
                {
                    string[] parts = cmd.Split(' ');

                    if (parts[0] == "q")
                    {
                        Console.WriteLine("bye!");
                        return;
                    }
                    else if (parts[0] == "=")
                    {
                        ram[int.Parse(parts[1])] = byte.Parse(parts[2]);
                    }
                    else if (parts[0] == "r")
                    {
                        running = true;
                    }
                    else if (parts[0] == "!")
                    {
                        running = false;
                        accumulator = 0;
                        programCounter = 0;
                        instructionRegister = 0;
                    }
                    else if (parts[0] == "s")
                    {
                        instructionRegister = ram[programCounter];

                        if (instructionRegister == 0x00)
                        {
                            //NOP (IMPLIED)                            
                            programCounter += 1;
                        }
                        else if (instructionRegister == 0x01)
                        {
                            //HLT (IMPLIED)                            
                            running = false;
                        }
                        else if (instructionRegister == 0x91)
                        {
                            //LDA (ABSOLUTE)
                            //load the accumulator with the value in ram at the location pointed to be the next two bytes after the opcode
                            byte high = ram[programCounter + 1];
                            byte low = ram[programCounter + 2];

                            //todo: this will only work for less than 255
                            accumulator = ram[low];

                            programCounter += 3;
                        }
                        else if (instructionRegister == 0x80)
                        {
                            //INCA (IMPLIED)
                            //increment the accumulator
                            accumulator++;

                            programCounter++;
                        }
                        else if (instructionRegister == 0x99)
                        {
                            //STA (ABSOLUTE)
                            //store the value in the accumulator into ram at the location pointed to be the next two bytes after the opcode
                            byte high = ram[programCounter + 1];
                            byte low = ram[programCounter + 2];

                            //todo: this will only work for less than 255
                            ram[low] = accumulator;


                            programCounter += 3;
                        }
                        else if (instructionRegister == 0x9B)
                        {
                            //STA (INDIRECT)
                            //store a value in the accumulator into ram at the location pointed to by the location pointed to
                            byte high = ram[programCounter + 1];
                            byte low = ram[programCounter + 2];
                           
                            programCounter = low;
                            
                            byte higher = ram[programCounter];
                            byte lower = ram[programCounter + 1];
                            
                            ram[lower] = accumulator;

                            programCounter += 2;
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
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("\tA: [" + accumulator.ToString("X2") + "]\t\tPC: [" + programCounter.ToString("X2") + "]\tIR:[" + instructionRegister.ToString("X2")+"]");
            Console.WriteLine("------------------------------------------------------------------------------");

            int a = 0;

            for (int i = 0; i < 15; ++i)
            {
                Console.Write("\t");
                
                for (int j = 0; j < 10; ++j)
                {

                    if (a == programCounter)
                    {
                        Console.Write(" [");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                    Console.Write(ram[a].ToString("X2"));

                    if (a == programCounter)
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
