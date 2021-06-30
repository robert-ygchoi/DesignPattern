using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    internal class CallController
    {
        public CallController(ICallCommand callCommand)
        {
            CallCommand = callCommand;
        }

        public ICallCommand CallCommand { get; private set; }

        public void SetCommand(ICallCommand callCommand)
        {
            this.CallCommand = callCommand;
        }

        public void RRRRRR()
        {
            CallCommand.Exec();
        }

    }
    internal interface ICallCommand
    {
        void Exec();
    }
    
    internal class Call
    {
        public void Receive() => Console.WriteLine("여보세요?");
        public void Reject() => Console.WriteLine("지금은 전화를 받을 수 없어 소리샘으로 연결되오니 삐 소리 후 ~");
        public void MessageReject(string message) => Console.WriteLine(message);
    }

    internal abstract class BaseCallCommand
    {
        public Call Call { get; protected set; }

        protected BaseCallCommand(Call call)
        {
            Call = call;
        }
    }

    internal class CallReceiveCommand : BaseCallCommand, ICallCommand
    {
        public CallReceiveCommand(Call call) : base(call)
        {
        }

        public void Exec()
        {
            this.Call.Receive();
        }
    }

    internal class CallRejectCommand : BaseCallCommand, ICallCommand
    {
        public CallRejectCommand(Call call) : base(call)
        {
        }

        public void Exec()
        {
            this.Call.Reject();
        }
    }
    internal class CallMessageRejectCommand : BaseCallCommand, ICallCommand
    {
        public string Message { get; protected set; }
        public CallMessageRejectCommand(Call call, string message) : base(call)
        {
            this.Message = message;
        }

        public void Exec()
        {
            this.Call.MessageReject(this.Message);
        }
    }

}
