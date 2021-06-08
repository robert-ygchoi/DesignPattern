using System;
using System.Linq;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            /// 쓰레드로부터 안전한지 아닌지 테스트하는 코드
            /// SingletonObject의 '#define Thread_Safe'를 주석, 주석제거 번갈아가며 테스트
            Parallel.ForEach(Enumerable.Range(0, 10), idx =>
            {
                SingletonObject.Instance.Print();
            });

            Console.Read();
        }
    }
}
