using System;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyFileManager proxyFileManager = new ProxyFileManager("이은혜");

            proxyFileManager.Create("hi.txt");
            /// Proxy 객체에 의해 삭제 실패
            proxyFileManager.Remove("hi.txt");

            proxyFileManager = new ProxyFileManager("최용국");
            /// Proxy 객체에 생성 실패
            proxyFileManager.Create("hi.pdf");

            proxyFileManager.Create("hello.jpg");
            proxyFileManager.Remove("hello.jpg");

            Console.Read();
        }
    }
}
