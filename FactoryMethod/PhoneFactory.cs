using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal interface Phone
    {
        bool PowerOff();
        bool PowerOn();
    }

    internal abstract class PhoneFactory
    {
        protected abstract int MaxVersion { get; }
        internal bool TestResult { get; private set; }
        protected abstract Phone CreatePhone(string model, int version);

        internal Phone TestPhone(string model, int version)
        {
            if (version > MaxVersion)
                return null;

            Phone phone = CreatePhone(model, version);

            TestResult |= phone.PowerOn();
            TestResult |= phone.PowerOff();

            return phone;
        }
    }

    internal class IPhoneFactory : PhoneFactory
    {
        protected override int MaxVersion => 12;

        protected override Phone CreatePhone(string model, int version)
        {
            if (model.Equals("pro"))
                return new IPhoenPro(version);
            else if (model.Equals("mini"))
                return new IPhoenMini(version);
            else
                return null;
        }
    }

    internal class GalaxyFactory : PhoneFactory
    {
        protected override int MaxVersion => 21;

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
