

/// 앞에 주석을 바꿔가며 쓰레드로부터 안전한 환경과 그렇지 않은 환경의 코드를 활성화 시킬 수 있다.
#define Thread_Safe

using System;

namespace Singleton
{

    class SingletonObject
    {
        /// <summary>
        /// 쓰레드로부터 안전하게 생성됐는지 확인하는 ID
        /// </summary>
        public string UniqueID { get; }
        private SingletonObject()
        {
            /// GUID 문자열만 저장
            UniqueID = $"{Guid.NewGuid():N}";
        }
#if Thread_Safe
        ///  static constructor의 특징을 이용하여 쓰레드로부터 안전하게 호출
        ///  REF: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-constructors
        ///  그 외에 lock(동기화)를 사용하여 아래 Thread_UnSafe 환경에서도 안전하게 호출할 수 있다.
        ///  

        public static SingletonObject Instance { get; }
        static SingletonObject()
        {
            Instance = new SingletonObject();
        }

        public void Print() => System.Console.WriteLine($"Thread Safe Singleton Instance ID: {UniqueID}");
#else
        private static SingletonObject _instance = null;
        public static SingletonObject Instance 
        { 
            get
            {
                if (_instance is null)
                    _instance = new SingletonObject();

                return _instance;
            }
        }

        public void Print() => System.Console.WriteLine($"Thread UnSafe Singleton Instance ID: {UniqueID}");
#endif
    }
}
