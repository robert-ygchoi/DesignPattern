using System;

namespace Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            KIMBOBFactory KIMBOBFactory = new KIMBOBFactory();

            KIMBOBFactory.GetKIMBOB(KIMBOBMenu.Normal);
            KIMBOBFactory.GetKIMBOB(KIMBOBMenu.Normal);

            KIMBOBFactory.GetKIMBOB(KIMBOBMenu.Vegetable);

            Console.Read();

        }
    }
}
