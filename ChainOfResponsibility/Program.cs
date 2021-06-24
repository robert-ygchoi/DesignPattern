using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            CoR cor = new CoR();

            Unit_1 unit_1 = new Unit_1();
            Unit_10 unit_10 = new Unit_10();
            Unit_100 unit_100 = new Unit_100();

            cor.Add(unit_100);
            cor.Add(unit_10);
            cor.Add(unit_1);

            cor.Calc(432);

            Console.Read();
        }
    }
}
