using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinBebop.Asm
{
   public class Operand
   {
      private AddressingModes _addressingMode;
      private Value _value;

      public AddressingModes AddressingMode
      {
         get
         {
            return _addressingMode;
         }
      }

      public Operand()
      {
         _addressingMode = AddressingModes.Implied;
         _value = null;
     }

      public Operand(Value value)
      {
         if (value!=null)
         {
            if (value.Size == 1)
            {
               _addressingMode = AddressingModes.Immediate;
            }
            else if (value.Size == 2)
            {
               if (value is Pointer)
               {
                  _addressingMode = AddressingModes.Absolute;
               }
               else
               {
                  _addressingMode = AddressingModes.BigImmediate;
               }
            }
            else
            {
               throw new NotSupportedException("operands of size {" + value.Size + "} not supported");
            }

         }
         else
         {
            _addressingMode = AddressingModes.Implied;
         }

         _value = value;
     }

      public Operand(Value value, AddressingModes addressingMode)
      {
         if (value == null)
         {
            if (_addressingMode != AddressingModes.Implied)
            {
               throw new InvalidOperationException("invalid address mode for null value operand {" + Enum.GetName(typeof(AddressingModes), addressingMode) + "}");
            }
         }
         else
         {
            //Absolute = 4,
            //Indexed = 8,
            //Indirect = 16,
            //IndirectPreIndexed = 32,
            //IndirectPostIndexed = 64
            if (new[] { 4, 8, 16, 32, 64 }.ToList().Contains((int)addressingMode))
            {
               if (value.Size != 2)
               {
                  throw new InvalidOperationException("invalid address mode {" + Enum.GetName(typeof(AddressingModes), addressingMode) + "}");
               }
            }
         }

         _addressingMode = addressingMode;
         _value = value;

      }

      public Value Value
      {
         get
         {
            return _value;
         }
      }

      public static Operand Parse(string text)
      {
         //v=LABEL | ($ff | 255 | %10101010) | ($ffff | 64000 | %1010101010101010

         //v
         //[v]
         //[[v]]
         //[v,X]
         //[[v,X]]
         //[[v],X]

         AddressingModes addressingMode = AddressingModes.Implied;

         string parsed = text;

         if (parsed != null)
         {
            bool isAddress = false;
            bool isIndirect = false;
            bool isIndexed = false;
            bool isPreIndexed = false;
            bool isPostIndexed = false;


            if (parsed[0] == '[')
            {
               if (parsed[parsed.Length - 1] != ']') throw new InvalidOperationException("can't parse {" + text + "}");

               isAddress = true;
               parsed = parsed.Substring(1, parsed.Length - 2);

               if (parsed[0] == '[')
               {

                  isIndirect = true;

                  if (parsed.Substring(parsed.Length - 3, 3) == ",X]")
                  {
                     isPreIndexed = true;
                     parsed = parsed.Substring(1, parsed.Length - 4);
                  }
                  else if (parsed.Substring(parsed.Length - 3, 3) == "],X")
                  {
                     isPostIndexed = true;
                     parsed = parsed.Substring(1, parsed.Length - 4);
                  }
                  else if (parsed[parsed.Length - 1] == ']')
                  {
                     parsed = parsed.Substring(1, parsed.Length - 2);
                  }
                  else
                  {
                     throw new InvalidOperationException("can't parse {" + text + "}");
                  }


               }

               if (parsed.Substring(parsed.Length - 2, 2) == ",X")
               {
                  isIndexed = true;
                  parsed = parsed.Substring(0, parsed.Length - 2);
               }

            }

            if (parsed.Length == 0) throw new InvalidOperationException("can't parse {" + text + "}");

            //parse label or literal
            UInt ui = null;
            string name = null;

            if (char.IsLetter(parsed[0])||parsed[0]=='_') 
            {
               if (!parsed.All(c => char.IsLetterOrDigit(c) || c=='_')) throw new InvalidOperationException("can't parse {" + text + "}");
               name = parsed;
            }
            else
            {
               ui = UInt.Parse(parsed);

               if (isAddress && ui is U8)
               {
                  ui = new U16(((U8)ui).Read());
               }

            }


            if (isAddress)
            {
               //address literal or pointer (label)
               if (isIndirect)
               {
                  if (isPreIndexed) addressingMode = AddressingModes.IndirectPreIndexed;
                  else if (isPostIndexed) addressingMode = AddressingModes.IndirectPostIndexed;
                  else addressingMode = AddressingModes.Indirect;
               }
               else 
               {
                  if (isIndexed)
                  {
                     addressingMode = AddressingModes.Indexed;
                  }
                  else
                  {
                     addressingMode = AddressingModes.Absolute;
                  }
               }

               Value value = null;

               if (ui!=null)
               {
                  value = new Literal(ui);
               }
               else
               {
                  value=new Pointer(name);
               }

               return new Operand(value, addressingMode);

            }
            else
            {
               //immediate literal or constant (label)
               if (ui!=null)
               {
                  if (ui is U8)
                  {
                     addressingMode = AddressingModes.Immediate;
                  }
                  else if (ui is U16)
                  {
                     addressingMode = AddressingModes.BigImmediate;
                  }
                  else
                  {
                     throw new NotSupportedException("only U8 and U16 supported");
                  }

                  return new Operand(new Literal(ui), addressingMode);
               }
               else
               {
                  //how to tell if a constant label is 8 or 16?
                  //TODO: look up .EQU in symbol table
                  return new Operand(new Constant(name,null), addressingMode);
               }
            }

         }
         else
         {
            //implied
            return new Operand();

         }

      }

      public override string ToString()
      {
         return Value.ToString() + "{"+ Enum.GetName(typeof(AddressingModes), _addressingMode) + "}";
      }


   }
}
