using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneFactory phoneFactory = new PhoneFactory();
            if(phoneFactory.CreatePhone("apple") is Phone applePhone)
            {
                applePhone.OS.SetUp();
                applePhone.Pay.Payment();
            }

            if(phoneFactory.CreatePhone("samsung") is Phone samsungPhone)
            {
                samsungPhone.OS.SetUp();
                samsungPhone.Pay.Payment();
            }

            Console.Read();
        }
    }
}
