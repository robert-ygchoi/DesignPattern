using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    /// ※ 구현 클래스에 의존하지 않고 구성요소를 인터페이스화 한다.
    /// 구성요소는 Phones.Phone의 멤버다.
    /// 

    internal interface IPhoneFactory
    {
        OS CreateOS();
        Pay CreatePay();
    }

    internal interface OS
    {
        void SetUp();
    }

    internal interface Pay
    {
        void Payment();
    }

    internal class PhoneFactory
    {
        internal Phone CreatePhone(string type)
        {
            /// C# 9.0 swtich 식
            /// REF: https://docs.microsoft.com/ko-kr/dotnet/csharp/whats-new/csharp-9#pattern-matching-enhancements
            IPhoneFactory phoneFactory = type switch
            {
                "apple" => new ApplePhoneFactory(),
                "samsung" => new SamsungPhoneFactory(),
                _ => null
            };

            if (phoneFactory != null)
            {
                return new Phone()
                {
                    OS = phoneFactory.CreateOS(),
                    Pay = phoneFactory.CreatePay()
                };
            }

            return null;
        }
    }

    /// 구성 요소 Factory
    /// IPhoneFactory를 확장한다. (Similar Factory Method)
    /// 

    internal class ApplePhoneFactory : IPhoneFactory
    {
        public OS CreateOS() => new IOS();

        public Pay CreatePay() => new ApplePay();
    }

    internal class SamsungPhoneFactory : IPhoneFactory
    {
        public OS CreateOS() => new Android();

        public Pay CreatePay() => new SamsungPay();
    }



}
