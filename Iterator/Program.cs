using System;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // 1. 문자열 컬렉션 컨테이너 생성
            // 2. 초기 buffer는 3개 추가는 4번
            // 3. 반복자 생성 후 반복하여 출력
            //
            MyStrContainer myStrContainer = new MyStrContainer(3);

            myStrContainer.Add("최용국");
            myStrContainer.Add("이은혜");
            myStrContainer.Add("최예윤");
            myStrContainer.Add("도로시");

            var myStrIter = myStrContainer.MakeIterator();
            myStrIter.Init();
            Console.WriteLine("======");
            while (myStrIter.Next())
            {
                Console.WriteLine($"{myStrIter.Current} 출력");
            }

            Console.Read();
        }
    }
}
