using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WinBebop.Asm;

namespace WinBebop.Core
{
   public class Beboputer
   {

      public static Beboputer Bebop { get; private set; } = new Beboputer();

      public static Dictionary<string, Type> Directives { get; private set; } = new Dictionary<string, Type>();
      public static Dictionary<string, Type> Instructions { get; private set; } = new Dictionary<string, Type>();
      public static Dictionary<string, byte> Opcodes { get; private set; } = new Dictionary<string, byte>();

      public List<Line> Lines { get; private set; } = new List<Line>();
      public Dictionary<string, Statement> Labels { get; private set; } = new Dictionary<string, Statement>();

      public CPU CPU { get; private set; } = new CPU();
      public RAM RAM { get; private set; } = new RAM();


      static Beboputer()
      {
         //find instructions and directives

         List<Type> directives = Assembly.GetAssembly(typeof(Directive)).GetTypes().Where(type => type.IsSubclassOf(typeof(Directive))).ToList<Type>();
         foreach (Type directive in directives)
         {
            MnemonicAttribute ma = (MnemonicAttribute)Attribute.GetCustomAttribute(directive, typeof(MnemonicAttribute));

            string mnemonic = directive.Name;

            if (ma != null)
            {
               mnemonic = ma.Mnemonic;
            }

            Directives.Add(mnemonic, directive);

         }

         List<Type> instructions = Assembly.GetAssembly(typeof(Instruction)).GetTypes().Where(type => type.IsSubclassOf(typeof(Instruction))).ToList<Type>();
         foreach (Type instruction in instructions)
         {
            MnemonicAttribute ma = (MnemonicAttribute)Attribute.GetCustomAttribute(instruction, typeof(MnemonicAttribute));

            string mnemonic = instruction.Name;

            if (ma != null)
            {
               mnemonic = ma.Mnemonic;
            }

            Instructions.Add(mnemonic, instruction);

            //opcodes
            OpcodeAttribute[] oas = (OpcodeAttribute[])Attribute.GetCustomAttributes(instruction, typeof(OpcodeAttribute));

            foreach (OpcodeAttribute oa in oas)
            {
               string key = mnemonic + "_" + Enum.GetName(typeof(AddressingModes), oa.AddressingMode);

               if (Beboputer.Opcodes.ContainsKey(key)) throw new InvalidOperationException("opcode key {"+key+"} already exists");

               Beboputer.Opcodes.Add(key, oa.Opcode);

            }

         }

      }

      public void Reset()
      {
         Stop();
         CPU.Reset();
         RAM.Reset();
         Lines.Clear();
         Labels.Clear();
         Load();
      }

      public delegate void LoadedEventHandler();

      public event LoadedEventHandler Loaded;

      public void Load()
      {
         if (Loaded != null) Loaded();
      }

      public void Stop()
      {

      }

   }
}
