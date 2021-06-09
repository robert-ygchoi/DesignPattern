using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMessage myMessage = new MyMessage()
                .SetSender("최용국")
                .SetReceiver("이은혜")
                .SetTitle("사랑하는 은혜에게")
                .SetMessage($"2021년 6월 9일 오늘 예윤이가 우리한테 온지 벌써 1년이 됐네\n" +
                $"1년 동안 고생 너무 많았고, 앞으로도 지금처럼 사랑하면서 예윤이 예쁘게 키우자");


            Console.WriteLine(myMessage);
            Console.Read();
        }
    }
}
