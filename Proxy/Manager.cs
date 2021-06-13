using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    /// 1. 프록시 객체는 특정 객체로 접근하는 것을 통제한다.
    ///    - 파일을 생성할 땐 지원하는 확장자만 생성한다.
    ///    - 파일을 삭제할 땐 지정된 ID만 삭제할 수 있다.
    /// 2. 프록시 객체는 특정 객체가 확장한 interface를 확장한다.
    /// 

    internal interface IManager
    {
        void Remove(string filename);
        void Create(string filename);
    }
    internal class FileManager : IManager
    {
        public void Create(string filename)
        {
            Console.WriteLine($"{filename} 파일 생성!!!");
        }

        public void Remove(string filename)
        {
            Console.WriteLine($"{filename} 파일 삭제!!!");
        }
    }

    internal class ProxyFileManager : IManager
    {
        private const string Admin = "최용국";
        internal static readonly string[] AllowExtensions = new[] { ".txt", ".jpg", ".png" };
        internal string ID { get; private set; }
        private FileManager FileManager { get; set; }
        internal ProxyFileManager(string id)
        {
            ID = id;
            FileManager = new FileManager();
        }
        public void Create(string filename)
        {
            if (!AllowExtensions.Any(ext => filename.EndsWith(ext)))
            {
                Console.WriteLine($"{filename} 지원하지 않는 파일 확장자입니다.");
                return;
            }
            FileManager.Create(filename);
        }

        public void Remove(string filename)
        {
            if(!ID.Equals(Admin))
            {
                Console.WriteLine($"{filename} 관리자만 파일을 삭제할 수 있습니다.");
                return;
            }

            FileManager.Remove(filename);
        }
    }

}
