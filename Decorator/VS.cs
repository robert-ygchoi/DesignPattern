using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal abstract class DeveloperTool
    {
        internal abstract void Setup();
    }
    internal abstract class DeveloperToolDecorator : DeveloperTool
    {
        private DeveloperTool Decorator { get; }

        protected DeveloperToolDecorator(DeveloperTool decorator)
        {
            Decorator = decorator;
        }

        internal override void Setup() => Decorator.Setup();
    }
    internal class VisualStudio : DeveloperTool
    {
        internal override void Setup() => Console.WriteLine("Visual Studio Install!!!");
    }

    internal class DotnetFramework : DeveloperToolDecorator
    {
        public DotnetFramework(DeveloperTool decorator) : base(decorator)
        {
        }

        internal override void Setup()
        {
            base.Setup();
            Framework45();
        }

        private void Framework45() => Console.WriteLine(".Net Framework 4.5 Install!!!");
    }

    internal class Winform : DeveloperToolDecorator
    {
        public Winform(DeveloperTool decorator) : base(decorator)
        {
        }

        internal override void Setup()
        {
            base.Setup();
            CSharpWinform();

        }
        private void CSharpWinform() => Console.WriteLine("C# Winform Install!!!");
    }

}
