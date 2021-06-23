using System;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Macro macro = new Macro(new StringContext());

            macro.Interpret("hello ascii; world utf8;");

            Console.ReadLine();
        }
    }
}
