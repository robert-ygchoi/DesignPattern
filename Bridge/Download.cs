using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    internal interface IDownload
    {
        string GetSource();
    }

    internal abstract class Download
    {
        protected Download(IDownload download)
        {
            IDownload = download;
        }

        private IDownload IDownload { get; }

        public void Downloading()
        {
            Console.WriteLine($"{IDownload.GetSource()} 에서 다운로드!!!");
        }
    }

    internal class GeneralDownload : Download
    {
        public GeneralDownload(IDownload download) : base(download)
        {
        }
    }

    internal class Ftp : IDownload
    {
        public string GetSource() => "FTP";
    }

    internal class Sftp : IDownload
    {
        public string GetSource() => "SFTP";
    }

    internal class P2P : IDownload
    {
        public string GetSource() => "P2P";
    }


}
