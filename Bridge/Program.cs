using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneralDownload generalDownload = new GeneralDownload(new Ftp());
            generalDownload.Downloading();

            generalDownload = new GeneralDownload(new Sftp());
            generalDownload.Downloading();

            generalDownload = new GeneralDownload(new P2P());
            generalDownload.Downloading();

            Console.Read();
        }
    }
}
