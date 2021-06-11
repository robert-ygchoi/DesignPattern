using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal interface Phone
    {
        void PowerOff();
        void PowerOn();
    }

    internal abstract class PhoneFactory
    {
        protected abstract int[] SupportedVersions { get; }
        internal bool TestResult { get; private set; }
        /// <summary>
        /// factory sub class에게 객체 생성의 구현부를 넘긴다
        /// </summary>
        /// <param name="model">모델이름</param>
        /// <param name="version">버전</param>
        /// <returns>생성된 phone class</returns>
        protected abstract Phone CreatePhone(string model, int version);


        internal Phone TestPhone(string model, int version)
        {
            if (!SupportedVersions.Contains(version))
            {
                Console.WriteLine($"{this.GetType().Name} 에서 지원하지 않는 버전입니다.\n입력된 버전: {version}\n지원 버전: {string.Join(", ", SupportedVersions)}");
                return null;
            }

            /// sub class factory에서 phone을 상속받은 object를 받아온다.
            Phone phone = CreatePhone(model, version);

            phone.PowerOn();
            phone.PowerOff();

            return phone;
        }
    }

    internal class IPhoneFactory : PhoneFactory
    {
        protected override int[] SupportedVersions => Enumerable.Range(1, 12).ToArray();

        /// <summary>
        /// sub class 객체 생성 구현부
        /// </summary>
        protected override Phone CreatePhone(string model, int version)
        {
            if (model.Equals(IPhone.ProModel))
                return new IPhonePro(version);
            else if (model.Equals(IPhone.MiniModel))
                return new IPhoneMini(version);
            else
                return null;
        }
    }

    internal class GalaxyFactory : PhoneFactory
    {
        protected override int[] SupportedVersions => Enumerable.Range(1, 10).Concat(new[] { 20 }).ToArray();

        /// <summary>
        /// sub class 객체 생성 구현부
        /// </summary>
        protected override Phone CreatePhone(string model, int version)
        {
            if (model.Equals("s"))
                return new GalaxyS(version);
            else if (model.Equals("note"))
                return new GalaxyNote(version);
            else
                return null;
        }
    }
}
