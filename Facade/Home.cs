using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    // 
    // Facade Model
    // 
    internal class Home
    {
        public Home()
        {
            Computer = new Computer();
            VisualStudio = new VisualStudio();
            GitHub = new GitHub();
        }

        Computer Computer { get; }
        VisualStudio VisualStudio { get; }
        GitHub GitHub { get; }

        bool Is { get; set; }
        //
        // 집에 들어왔을 때 행위
        //
        internal void In()
        {
            // 0. 이미 집에 있는지 확인
            if(Is)
            {
                Console.WriteLine("이미 집에 있습니다.");
                return;
            }

            // 1. 컴퓨터 켜기
            Computer.On();
            // 2. VS 열기
            VisualStudio.Open();
            // 3. 코딩하기
            VisualStudio.Write();

            // final 집에 들어왔다고 설정
            Is = true;
        }

        //
        // 집에서 나갈 때 행위
        //
        internal void Out()
        {
            // 0. 이미 집에서 나갔는지 확인
            if (!Is)
            {
                Console.WriteLine("아직 집에 들어오지 않았습니다.");
                return;
            }
            // 1. 코드 커밋
            GitHub.Commit();
            // 2. 코드 푸쉬
            GitHub.Push();
            // 3. VS 닫기
            VisualStudio.Close();
            // 4. 컴퓨터 끄기
            Computer.Off();

            // final 집에서 나갔다고 설정
            Is = false;
        }
    }

    internal class Computer
    {
        internal void On() => Console.WriteLine("컴퓨터 On");
        internal void Off() => Console.WriteLine("컴퓨터 Off");
    }

    internal class VisualStudio
    {
        internal void Open() => Console.WriteLine("Visual Studio 2019 Open");
        internal void Write() => Console.WriteLine("Coding... Facade Pattern");
        internal void Close() => Console.WriteLine("Visual Studio 2019 Close");
    }

    internal class GitHub
    {
        internal void Commit() => Console.WriteLine("Git Commit");
        internal void Push() => Console.WriteLine("Git Push");
    }





}
