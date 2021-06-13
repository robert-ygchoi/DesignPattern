using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// interface에 필요한 기능들을 캡슐화하여 정의한다. 이를 Adapter로 본다. (IMessenger)
/// 행위를 하는 객체를 두고(Messenger) 멤버로 캡슐화된 interface, 즉 Adapter를 받는다.
/// Adapter로 사용될 객체는 IMessenger를 확장하여 구현한다.
/// 행위하는 객체는 Adapter를 변경할 수 있게 Change Method를 제공한다.
/// 

namespace Adapter
{
    internal interface IMessenger
    {
        void SignIn();
        void SignOut();
        void Send(string message);
        void Receive();
    }
    internal class Messenger
    {
        internal IMessenger MyMessenger { get; private set; }


        public Messenger(IMessenger messenger)
        {
            MyMessenger = messenger;
        }

        public void ChangeMessenger(IMessenger messenger) => MyMessenger = messenger;

        public void Send(string message)
        {
            MyMessenger.SignIn();
            MyMessenger.Send(message);
            MyMessenger.SignOut();
        }

        public void Receive()
        {
            MyMessenger.SignIn();
            MyMessenger.Receive();
            MyMessenger.SignOut();
        }
    }
    internal abstract class BaseMessenger
    {
        protected string Message { get; set; }
        internal string ID { get; private set; }
        internal string PW { get; private set; }
        protected BaseMessenger(string id, string pw)
        {
            ID = id;
            PW = pw;
        }

    }
    internal class KAKAO : BaseMessenger, IMessenger
    {
        public KAKAO(string id, string pw) : base(id, pw)
        {
        }

        public void Receive() => Console.WriteLine($"from 카카오: {Message}");

        public void Send(string message) => Console.WriteLine($"to 카카오: {Message = message}");

        public void SignIn() => Console.WriteLine($"카카오 로그인 ID: {ID} PW: {PW}");

        public void SignOut() => Console.WriteLine($"카카오 로그아웃 ID: {ID} PW: {PW}");
    }

    internal class LINE : BaseMessenger, IMessenger
    {
        public LINE(string id, string pw) : base(id, pw)
        {
        }

        public void Receive() => Console.WriteLine($"from 라인: {Message}");

        public void Send(string message) => Console.WriteLine($"to 라인: {Message = message}");

        public void SignIn() => Console.WriteLine($"라인 로그인 ID: {ID} PW: {PW}");

        public void SignOut() => Console.WriteLine($"라인 로그아웃 ID: {ID}, PW: {PW}");
    }

}
