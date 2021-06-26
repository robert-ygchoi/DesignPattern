using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class IPhone : IElement
    {
        public string OS => "IOS";

        public void Accept(BasePhoneVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    internal class Galaxy : IElement
    {
        public string OS => "Android";
        public void Accept(BasePhoneVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    internal class VersionVisitor : BasePhoneVisitor
    {
        public override void Visit(IPhone iPhone)
        {
            Console.WriteLine($"아이폰을 방문했습니다. 운영체제는 {iPhone.OS}");
        }

        public override void Visit(Galaxy galaxy)
        {
            Console.WriteLine($"갤럭시를 방문했습니다. 운영체제는 {galaxy.OS}");
        }
    }


    internal abstract class BasePhoneVisitor
    {
        public abstract void Visit(IPhone iPhone);
        public abstract void Visit(Galaxy galaxy);
    }

    
    internal interface IElement
    {
        public void Accept(BasePhoneVisitor visitor);
    }
}
