using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    //
    // 컬렉션이 되는 컨테이너
    //
    internal interface IContainer<T>
    {
        void Add(T item);
        void Clear();
        int Count { get; }
    }

    //
    // 컬렉션에 접근하는 반복자
    //
    internal interface IIterator<T>
    {
        void Init();
        bool Next();
        T Current { get; }
    }

    //
    // 문자열 컬렉션 컨테이너
    //
    internal class MyStrContainer : IContainer<string>
    {
        //
        // 문자열 컬렉션
        //
        private string[] Buffer { get; set; }

        //
        // 생성자에서 컬렉션 초기화
        //
        public MyStrContainer(int buffer)
        {
            Buffer = new string[buffer];
        }
        public int Count { get; private set; }

        public void Add(string item)
        {
            if (Buffer is null || Buffer.Length == Count)
            {
                Console.WriteLine($"{item}: 꽉 찼어유!!");
                return;
            }
            Console.WriteLine($"{item} 추가 했어유!!!");
            Buffer[Count] = item;
            Count++;
        }

        public void Clear()
        {
            Buffer = null;
            Count = 0; 
        }

        //
        // 문자열에 접근하는 반복자 생성
        //
        public IIterator<string> MakeIterator() => new MyStrIterator(this.Buffer, Count);

        //
        // 문자열 반복자 클래스
        // 외부에서 생성하지 못하게 inner class로 정의
        //
        private class MyStrIterator : IIterator<string>
        {
            private string[] Buffer { get; set; }
            private int Size { get; set; }
            private int Index { get; set; }
            public MyStrIterator(string[] buffer, int size)
            {
                Buffer = buffer;
                Size = size;
            }

            public string Current => Buffer[Index];

            public void Init()
            {
                Index = -1;
            }

            public bool Next()
            {
                Index++;
                if (Index >= Size)
                    return false;

                return true;
            }
        }
    }

    

}
