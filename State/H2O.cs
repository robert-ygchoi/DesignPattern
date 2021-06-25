using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    internal interface IH2O
    {
        void Freeze(H2O h2o);
        void Melt(H2O h2o);
    }

    internal class H2O
    {
        public H2O()
        {
            State = new Water();
        }

        public IH2O State { get; set; }

        public void View() => Console.WriteLine($"{State.GetType().Name}");

        public void Freeze() => State.Freeze(this);
        public void Melt() => State.Melt(this);
    }

    internal class ICE : IH2O
    {
        public void Freeze(H2O h2o)
        {
            Console.WriteLine("이미 꽁꽁 얼었습니다.");
        }

        public void Melt(H2O h2o)
        {
            Console.WriteLine("얼음이 녹았습니다.");
            h2o.State = new Water();
        }
    }

    internal class Water : IH2O
    {
        public void Freeze(H2O h2o)
        {
            Console.WriteLine("물이 얼어 버렸습니다.");
            h2o.State = new ICE();
        }

        public void Melt(H2O h2o)
        {
            Console.WriteLine("물이 끓었습니다.");
            h2o.State = new Vapor();
        }
    }

    internal class Vapor : IH2O
    {
        public void Freeze(H2O h2o)
        {
            Console.WriteLine("수증기가 맺혔습니다.");
            h2o.State = new Water();
        }

        public void Melt(H2O h2o)
        {
            Console.WriteLine("더 이상 녹을 수 없습니다.");
        }
    }

}
