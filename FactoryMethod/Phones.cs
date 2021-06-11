using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    internal class IPhoenPro : Phone
    {
        internal int Version { get; private set; }

        public IPhoenPro(int version)
        {
            Version = version;
        }

        public bool PowerOff()
        {
            var result = DateTime.Now.Ticks % 2 == 0;
            Console.WriteLine($"아이폰프로{Version} 전원 Off {result}");
            return result;
        }

        public bool PowerOn()
        {
            var result = DateTime.Now.Ticks % 2 == 0;
            Console.WriteLine($"아이폰프로{Version} 전원 On {result}");
            return result;
        }
    }

    internal class IPhoenMini : Phone
    {
        internal int Version { get; private set; }

        public IPhoenMini(int version)
        {
            Version = version;
        }

        public bool PowerOff()
        {
            var result = DateTime.Now.Ticks % 2 == 0;
            Console.WriteLine($"아이폰미니{Version} 전원 Off {result}");
            return result;
        }

        public bool PowerOn()
        {
            var result = DateTime.Now.Ticks % 2 == 0;
            Console.WriteLine($"아이폰미니{Version} 전원 On {result}");
            return result;
        }
    }

    internal class GalaxyS : Phone
    {
        internal int Version { get; private set; }

        public GalaxyS(int version)
        {
            Version = version;
        }
        public bool PowerOff()
        {
            var result = DateTime.Now.Ticks % 2 == 0;
            Console.WriteLine($"갤럭시S{Version} 전원 Off {result}");
            return result;
        }

        public bool PowerOn()
        {
            var result = DateTime.Now.Ticks % 2 == 0;
            Console.WriteLine($"갤럭시S{Version} 전원 On {result}");
            return result;
        }
    }

    internal class GalaxyNote : Phone
    {
        internal int Version { get; private set; }

        public GalaxyNote(int version)
        {
            Version = version;
        }
        public bool PowerOff()
        {
            var result = DateTime.Now.Ticks % 2 == 0;
            Console.WriteLine($"갤럭시노트{Version} 전원 Off {result}");
            return result;
        }

        public bool PowerOn()
        {
            var result = DateTime.Now.Ticks % 2 == 0;
            Console.WriteLine($"갤럭시노트{Version} 전원 On {result}");
            return result;
        }
    }

}
