using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            H2O h2o = new H2O();
            // water
            h2o.View();

            // ice
            h2o.Freeze();
            h2o.Freeze();
            h2o.View();

            // water
            h2o.Melt();
            // vapor
            h2o.Melt();
            h2o.Melt();
            h2o.View();
        }
    }
}
