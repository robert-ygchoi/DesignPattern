using System;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            IPhone phone = new IPhone();
            Galaxy galaxy = new Galaxy();

            VersionVisitor versionVisitor = new VersionVisitor();

            phone.Accept(versionVisitor);
            galaxy.Accept(versionVisitor);

            Console.Read();
        }
    }
}
