using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneFactory phoneFactory = new IPhoneFactory();
            var mini = phoneFactory.TestPhone(IPhone.MiniModel, 10);
            var pro = phoneFactory.TestPhone(IPhone.ProModel, 12);

            GalaxyFactory galaxyFactory = new GalaxyFactory();
            var s = galaxyFactory.TestPhone(Galaxy.SModel, 20);
            var note = galaxyFactory.TestPhone(Galaxy.NoteModel, 22);

            Console.Read();

        }
    }
}
