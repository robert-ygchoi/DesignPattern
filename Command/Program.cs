using System;

namespace Command
{
    class Program
    {
        //
        // 1. 회의 시간에 전화를 받는다.
        // 2. 중요한 회의시간에 전화를 받지 않는다.
        //   2-1. 중요한 사람이라면 문자 메시지를 보낸다.
        //
        static void Main(string[] args)
        {
            string time = "meeting";

            var receiveCommand = new CallReceiveCommand(new Call());
            var rejectCommand = new CallRejectCommand(new Call());
            var messageRejectCommand = new CallMessageRejectCommand(new Call(), "회의중이니 다음에 전화드리겠습니다.");
            CallController callController = new CallController(receiveCommand);

            Console.Write($"{time} ");
            if (time == "meeting") // 상황에 이해를 돕기위한 if 문
                callController.RRRRRR();

            
            time = "important meeting";
            callController.SetCommand(rejectCommand);

            Console.Write($"{time} ");
            if (time == "important meeting")
                callController.RRRRRR();

            string person = "vip";

            if(time == "important meeting" && person == "vip")
                callController.SetCommand(messageRejectCommand);

            Console.Write($"{time} ");
            callController.RRRRRR();


            Console.Read();
        }
    }
}
