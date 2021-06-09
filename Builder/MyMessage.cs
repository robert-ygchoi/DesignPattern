


/// 프로퍼티들의 같은 데이터 타입으로 인해
/// 생성자 오버로딩에 어려움이 있다.
/// 아래 define을 주석하고 생성자쪽 코드에서 발생하는 컴파일 오류를 확인한다.
#define BuilderPattern

namespace Builder
{
    internal class MyMessage
    {
        internal string Sender { get; private set; }
        internal string Receiver { get; private set; }
        internal string Title { get; private set; }
        internal string Message { get; private set; }

        public override string ToString() => $"보낸이:\t{Sender}\n받는이:\t{Receiver}\n제목:\t{Title}\n메시지내용:\t{Message}";

#if BuilderPattern
        internal MyMessage()
        {

        }
        internal MyMessage SetSender(string sender)
        {
            Sender = sender;
            return this;
        }
        internal MyMessage SetReceiver(string receiver)
        {
            Receiver = receiver;
            return this;
        }
        internal MyMessage SetTitle(string title)
        {
            Title = title;
            return this;
        }
        internal MyMessage SetMessage(string message)
        {
            Message = message;
            return this;
        }

#else
        
        internal MyMessage() : this("", "")
        {
        }

        internal MyMessage(string sender, string receiver, string title) : this(sender, receiver)
        {
            Title = title;
        }

        internal MyMessage(string sender, string receiver, string message) : this(sender, receiver)
        {
            Message = message;
        }

        internal MyMessage(string sender, string receiver) : this(sender, receiver, "", "")
        {
        }

        internal MyMessage(string sender, string receiver, string title, string message)
        {
            Sender = sender;
            Receiver = receiver;
            Title = title;
            Message = message;
        }
#endif

        /// builder parrtern으로 극복



    }
}
