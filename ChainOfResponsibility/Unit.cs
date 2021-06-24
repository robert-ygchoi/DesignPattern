using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    internal class CoR
    { 
        Unit Head { get; set; }
        Unit Tail { get; set; }

        public void Add(Unit unit)
        {
            if(Head != null)
            {
                Tail.Successor = unit;
                Tail = unit;
            }
            else
            {
                Head = Tail = unit;
            }
        }

        public void Calc(int number)
        {
            if (Head != null)
                Head.Calc(number);
        }
    }

    internal abstract class Unit
    {

        public Unit Successor { get; set; }
        public abstract void Calc(int number);

    }

    internal class Unit_1 : Unit
    {
        public override void Calc(int number)
        {
            if (number < 1)
                return;

            int remainder = number % 10;

            Console.WriteLine($"1의 자리: {remainder}");
        }
    }

    internal class Unit_10 : Unit
    {
        public override void Calc(int number)
        {
            if (number < 1)
                return;

            int quotient = number / 10;
            int remainder = number % 10;

            Console.WriteLine($"10의 자리: {quotient}");
            if (Successor != null)
                Successor.Calc(remainder);
        }
    }

    internal class Unit_100 : Unit
    {
        public override void Calc(int number)
        {
            if (number < 1)
                return;

            int quotient = number / 100;
            int remainder = number % 100;
            
            Console.WriteLine($"100의 자리: {quotient}");
            if (Successor != null)
                Successor.Calc(remainder);
        }
    }


}
