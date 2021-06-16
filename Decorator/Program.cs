using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var visualStudio = new VisualStudio();
            visualStudio.Setup();
            Console.WriteLine("=======================");
            var dotnetFramework = new DotnetFramework(visualStudio);
            dotnetFramework.Setup();
            Console.WriteLine("=======================");
            var winform = new Winform(dotnetFramework);
            winform.Setup();

        }
    }
}
