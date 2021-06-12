using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    internal class Phone
    {
        internal OS OS { get; set; }
        internal Pay Pay { get; set; }
    }

    /// OS, Pay구성 요소 구현
    /// 

    internal class IOS : OS
    {
        public void SetUp() => Console.WriteLine("IOS Setup");
    }

    internal class Android : OS
    {
        public void SetUp() => Console.WriteLine("Android Setup");
    }

    internal class ApplePay : Pay
    {
        public void Payment() => Console.WriteLine("paid by apple pay");
    }

    internal class SamsungPay : Pay
    {
        public void Payment() => Console.WriteLine("paid by samsung pay");
    }



}
