using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    //
    // 컴포짓 패턴을 이해하기엔 디렉토리와 파일 관계를 표현하는게 이해가 가장 쉽다.
    // 폴더와 파일의 공통 구현부분을 추상화 하고 컴포넌트로 활용
    //

    internal abstract class Component
    {
        public string Name { get; private set; }

        protected Component(string name)
        {
            Name = name;
        }
    }

    internal class MyFile : Component
    {
        public MyFile(string name) : base(name)
        {
        }
    }

    internal class MyDirectory : Component
    {
        private List<Component> Children { get; set; }
        public MyDirectory(string name) : base(name)
        {
            Children = new List<Component>();
        }


        public void AddChild(Component child) => Children.Add(child);

        public void RemoveChild(Component child) => Children.Remove(child);


        public void Show()
        {
            Console.WriteLine($"name: {Name} type: {this.GetType().Name}");

            foreach (var child in Children)
            {
                if (child is MyDirectory myDirectory)
                    myDirectory.Show();
                else
                    Console.WriteLine($"name: {child.Name} type: {child.GetType().Name}");
            }
        }

    }

}
