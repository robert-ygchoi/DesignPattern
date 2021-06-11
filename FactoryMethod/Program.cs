using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneFactory phoneFactory = new IPhoneFactory();
            var mini = phoneFactory.TestPhone("mini", 12);
            var pro = phoneFactory.TestPhone("pro", 12);

            GalaxyFactory galaxyFactory = new GalaxyFactory();
            var s = galaxyFactory.TestPhone("s", 20);
            var note = galaxyFactory.TestPhone("note", 20);

            Console.Read();

        }
    }
}
