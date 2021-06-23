using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interpreter
{
    internal class StringContext
    {
        public byte[] GetASCII(string str) => Encoding.ASCII.GetBytes(str);
        public byte[] GetUTF8(string str) => Encoding.UTF8.GetBytes(str);
    }

    internal interface IStringExpression
    {
        byte[] Interpret(StringContext context);
    }

    internal class StringToASCII : IStringExpression
    {
        public string Text { get; private set; }

        public StringToASCII(string text)
        {
            Text = text;
        }

        public byte[] Interpret(StringContext context) => context.GetASCII(Text);
    }

    internal class StringToUTF8 : IStringExpression
    {
        public string Text { get; private set; }

        public StringToUTF8(string text)
        {
            Text = text;
        }

        public byte[] Interpret(StringContext context) => context.GetUTF8(Text);
    }

    internal class Macro
    {
        StringContext Context { get; set; }

        public Macro(StringContext context)
        {
            Context = context;
        }

        public void Interpret(string text)
        {
            //
            // rule: (text)(space)(context)
            // separator: ;
            // ex: hello hex; hello base64
            //
            foreach (var command in Split(text, ';'))
            {
                var splitCommand = Split(command, ' ').ToArray();
                if(splitCommand.Length != 2)
                {
                    Console.WriteLine($"잘못된 명령어 입니다.\n{command}");
                    continue;
                }
                IStringExpression expression = splitCommand[1] switch
                {
                    "utf8" => new StringToUTF8(splitCommand[0]),
                    "ascii" => new StringToASCII(splitCommand[0]),
                    _ => null
                };

                if(expression is null)
                {
                    Console.WriteLine($"알 수 없는 명력어 입니다.\n{command}");
                    continue;
                }

                Console.WriteLine($"{command} => {string.Join(" ",expression.Interpret(Context))}");
            }

        }

        private IEnumerable<string> Split(string text, char splitChar) => text.Split(splitChar).Where(splitText => !string.IsNullOrEmpty(splitText));
    }
}
