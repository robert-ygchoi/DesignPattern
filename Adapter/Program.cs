using System;



namespace Adapter
{
    class Program
    {
        const string ID = "최용국";
        const string PW = "1234!@#$";
        static void Main(string[] args)
        {
            LINE line = new LINE(ID, PW);
            KAKAO kakao = new KAKAO(ID, PW);

            /// 최초 Lien Messenger로 Adapter 설정
            Messenger messenger = new Messenger(line);

            messenger.Send("안녕 라인 반가웡");
            Console.WriteLine();
            messenger.Receive();
            Console.WriteLine();


            /// Kakao Messenger로 Adapter 변경
            messenger.ChangeMessenger(kakao);
            messenger.Send("안녕 카카오 반가웡");
            Console.WriteLine();
            messenger.Receive();


            Console.Read();
        }
    }
}
