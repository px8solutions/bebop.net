using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinBebop.Core;
using WinBebop.Directives;

namespace WinBebop.Asm
{
   public class Assembler
   {
      public static void Assemble(string[] lines, IOutput output)
      {
         Beboputer.Bebop.Reset();

         bool errors = false;

         for (int i = 0; i < lines.Length; ++i)
         {
            //FOO:   .EQU    $FF   # this is a comment
            //FOO:   .BYTE   $FF,$FF,$FF   # this is a comment
            //FOO:   LDA     $FF   # this is a comment

            //{LABEL} {DIR|INS} {UINT|OPERAND} {COMMENT}

            try
            {

               string[] parts = lines[i].Split((char[])null, StringSplitOptions.RemoveEmptyEntries);
               int p = 0;

               string label = null;
               string comment = null;
               Line line = null;

               if (parts.Length>0 && parts[0].Length > 0)
               {

                  //label
                  if (char.IsLetter(parts[p][0]) || parts[p][0] == '_')
                  {
                     if (parts[p][parts[p].Length - 1] == ':')
                     {
                        label = parts[p].Substring(0, parts[p].Length - 1);
                        ++p;
                     }
                  }

                  if (parts[p][0] == '.') //directive
                  {
                     if (parts[p].Length == 1) throw new InvalidOperationException("can't parse line " + i + " {" + lines[i] + "}");
                     string dir = parts[p].Substring(1, parts[p].Length - 1);

                     if (Beboputer.Directives.ContainsKey(dir))
                     {

                        ++p;

                        string parm = null;

                        if (p < parts.Length)
                        {
                           if (parts[p][0] != '#')
                           {
                              parm = parts[p];
                              ++p;
                           }
                        }

                        Directive directive = (Directive)Activator.CreateInstance(Beboputer.Directives[dir]);

                        if (parm != null)
                        {
                           directive.Value = UInt.Parse(parm);
                        }

                        line = directive;
                     }
                     else
                     {
                        throw new InvalidOperationException("unknown directive line " + i + " {" + lines[i] + "}");
                     }

                  }
                  else if (Beboputer.Instructions.ContainsKey(parts[p])) //instruction
                  {
                     string ins = parts[p];
                     ++p;

                     string parm = null;

                     if (p < parts.Length)
                     {
                        if (parts[p][0] != '#')
                        {
                           parm = parts[p];
                           ++p;
                        }
                     }

                     Instruction instruction = (Instruction)Activator.CreateInstance(Beboputer.Instructions[ins]);

                     if (parm != null)
                     {
                        instruction.Operand = Operand.Parse(parm);
                     }

                     line = instruction;

                  }
                  else if (parts[p][0] == '#') //comment only line
                  {
                     //this is okay
                  }
                  else
                  {
                     throw new InvalidOperationException("unknown instruction line " + i + " {" + lines[i] + "}");
                  }

                  if (p < parts.Length)
                  {
                     if (parts[p][0] == '#')
                     {
                        parts[p] = parts[p].Substring(1, parts[p].Length - 1);
                        comment = "";

                        for (int j = p; j < (parts.Length); ++j)
                        {
                           if (comment != "") comment += " ";
                           comment += parts[j];
                        }
                     }
                     else
                     {
                        throw new InvalidOperationException("unknown syntax line " + i + " {" + lines[i] + "}");
                     }
                  }
               }

               if (line == null)
               {
                  if (comment != null)
                  {
                     line = new Comment();
                  }
                  else
                  {
                     if (lines[i].Trim().Length!=0) throw new InvalidOperationException("can't parse line " + i + " {" + lines[i] + "}");
                     line = new Line();
                  }
               }

               line.Text = lines[i];

               if (line is Statement)
               {
                  ((Statement)line).Label = label;
                  ((Statement)line).Comment = comment;

                  if (label!=null)
                  {
                     if (Beboputer.Bebop.Labels.ContainsKey(label)) throw new InvalidOperationException("label {"+label+"} already exists line " + i + " {" + lines[i] + "}");
                     Beboputer.Bebop.Labels.Add(label, (Statement)line);
                  }

               }
               else
               {
                  if (label != null) throw new InvalidOperationException("label invalid for line " + i + " {" + lines[i] + "}");
               }

               Beboputer.Bebop.Lines.Add(line);

               output.Out(i+":\t"+line.ToString());
            }
            catch (Exception ex)
            {
               errors = true;
               output.Out("ERROR: "+i + ":\t" + ex.Message);
            }

         }

         //load
         ushort address = 0;

         foreach (Line line in Beboputer.Bebop.Lines)
         {
            if (line is ORG)
            {
               address = ((U16)((ORG)line).Value).Read();
            }
            else if (line is Instruction)
            {
               Instruction ins = (Instruction)line;

               byte opcode;
               if (Beboputer.Opcodes.ContainsKey(Instruction.GetOpcodeKey(ins.Mnemonic, ins.AddressingMode)))
               {
                  opcode = Beboputer.Opcodes[Instruction.GetOpcodeKey(ins.Mnemonic, ins.AddressingMode)];
               }
               else
               {
                  throw new InvalidOperationException("no opcode for {"+ins.ToString()+"}");
               }

               Beboputer.Bebop.RAM.Write(address, opcode);
               ++address;

               if (ins.Operand!=null)
               {
                  if (ins.Operand.Value is Literal)
                  {
                     Literal l = (Literal)ins.Operand.Value;

                     if (l.Value is U8)
                     {
                        Beboputer.Bebop.RAM.Write(address, ((U8)l.Value).Read());
                        ++address;
                     }
                     else if (l.Value is U16)
                     {
                        ushort v = ((U16)l.Value).Read();
                        Beboputer.Bebop.RAM.Write(address, (byte)((v & 0xFF00)>>8));
                        ++address;
                        Beboputer.Bebop.RAM.Write(address, (byte)(v & 0xFF));
                        ++address;
                     }
                  }
                  else
                  {
                     throw new NotImplementedException("not yet");
                  }

               }

            }
         }

         //refresh windows
         Beboputer.Bebop.Load();


      }


   }
}
