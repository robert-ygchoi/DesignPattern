using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            Home home = new Home();

            // 집 들어가기
            home.In();
            Console.WriteLine("=====");
            // fail 1. 한번 더 들어가기
            home.In();
            Console.WriteLine("=====");
            // 집 나가기
            home.Out();
            Console.WriteLine("=====");
            // fail 2. 한번 더 나가기
            home.Out();

            Console.ReadLine();
        }
    }
}
