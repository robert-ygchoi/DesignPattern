using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // 1. 신세계에서 이벤트 상품을 n% 세일한다.
            //

            SinSaeGaeMall sinSaeGaeMall = new SinSaeGaeMall();
            NIKE nike = new NIKE();
            NBA nba = new NBA();

            sinSaeGaeMall.Add(nike);
            sinSaeGaeMall.Add(nba);

            sinSaeGaeMall.Notify(30);


            Console.Read();
        }
    }
}
