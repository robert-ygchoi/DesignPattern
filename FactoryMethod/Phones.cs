using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    /// <summary>
    /// phone super class
    /// </summary>
    internal abstract class BsaePhone
    {
        internal abstract string BaseName { get; }
        internal abstract string Name { get; }
        internal int Version { get; private set; }

        protected BsaePhone(int version)
        {
            Version = version;
        }

        internal string ModelName => $"{BaseName}{Name}{Version}";

        protected void PrintPowerOnMessage() => Console.WriteLine($"{ModelName} 전원 on");
        protected void PrintPowerOffMessage() => Console.WriteLine($"{ModelName} 전원 off");
    }

    /// <summary>
    /// iphone super class
    /// </summary>
    internal abstract class IPhone : BsaePhone
    {
        internal const string MiniModel = "mini";
        internal const string ProModel = "pro";

        internal override string BaseName => "아이폰";

        protected IPhone(int version) : base(version)
        {
        }
    }

    /// sub class들은 factory method pattern을 위해
    /// phone interface를 확장한다.
    /// BasePhone 으로 factory return type을 대체하여도 되는 구조이나 
    /// BasePhone을 따라가지 않는 모델들의 확장성을 위해 phone interface로 한다.

    /// <summary>
    /// iphone pro sub class 
    /// </summary>
    internal class IPhonePro : IPhone, Phone
    {
        
        internal IPhonePro(int version) : base(version)
        {
        }

        internal override string Name => "프로";

        public void PowerOff() => PrintPowerOffMessage();

        public void PowerOn() => PrintPowerOnMessage();
    }

    /// <summary>
    /// iphone mini sub class
    /// </summary>
    internal class IPhoneMini : IPhone, Phone
    {
        public IPhoneMini(int version) : base(version)
        {
        }

        internal override string Name => "미니";

        public void PowerOff() => PrintPowerOffMessage();

        public void PowerOn() => PrintPowerOnMessage();
    }
    /// <summary>
    /// galaxy super class
    /// </summary>
    internal abstract class Galaxy : BsaePhone
    {
        internal const string NoteModel = "note";
        internal const string SModel = "s";

        internal override string BaseName => "갤럭시";
        protected Galaxy(int version) : base(version)
        {
        }
    }

    /// <summary>
    /// galaxy s sub class
    /// </summary>
    internal class GalaxyS : Galaxy, Phone
    {
        internal GalaxyS(int version) : base(version)
        {
        }

        internal override string Name => "S";

        public void PowerOff() => PrintPowerOffMessage();

        public void PowerOn() => PrintPowerOnMessage();
    }

    /// <summary>
    /// galaxy note sub class
    /// </summary>
    internal class GalaxyNote : Galaxy, Phone
    {
        internal GalaxyNote(int version) : base(version)
        {
        }

        internal override string Name => "노트";

        public void PowerOff() => PrintPowerOffMessage();

        public void PowerOn() => PrintPowerOnMessage();
    }

}
