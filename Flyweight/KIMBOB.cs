using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    /// Factory에 객체 풀을 만들어놓고 이미 만들어놓은 객체가 있다면 반환한다.
    ///     ※ Dictionary의 Key 값으로 Enum형식을 쓰려면 .Net 4.x 이상 버전에서 써야한다.
    ///     REF: https://enghqii.tistory.com/69
    /// 얕은 복사가 이뤄지기 때문에 값 변경에 주의해야 한다.
    /// 

    internal enum KIMBOBMenu
    {
        Normal,
        Vegetable,
    }

    internal class KIMBOBFactory
    {
        public KIMBOBFactory()
        {
            Pool = new Dictionary<KIMBOBMenu, KIMBOB>();
        }

        private Dictionary<KIMBOBMenu, KIMBOB> Pool { get; set; }

        public KIMBOB GetKIMBOB(KIMBOBMenu menu)
        {
            if (Pool.TryGetValue(menu, out KIMBOB kimbob))
            {
                Console.WriteLine($"만들어놓은 {menu} 김밥");
                return kimbob;
            }

            KIMBOB newKIMBOB = new KIMBOB(menu);
            Pool.Add(menu, newKIMBOB);

            return newKIMBOB;
        }
    }


    internal class KIMBOB
    {
        internal KIMBOBMenu Menu { get; private set; }

        public KIMBOB(KIMBOBMenu menu)
        {
            Menu = menu;
            Console.WriteLine($"{menu} 김밥 만들기");
        }
    }
}
