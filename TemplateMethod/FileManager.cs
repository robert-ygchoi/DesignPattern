using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal abstract class FileManager
    {
        protected abstract FileStream CreateFile();

        protected abstract void Finished(StreamWriter writer);

        //
        // Template Method
        //
        public void Create()
        {
            using StreamWriter writer = new StreamWriter(CreateFile());

            writer.WriteLine("FileManager Template Method!!!");

            Finished(writer);

            writer.WriteLine("bye~ bye~");
        }
    }

    internal class MyFile : FileManager
    {
        protected override FileStream CreateFile() => File.Create("../../../myFile.txt");

        protected override void Finished(StreamWriter writer)
        {
            writer.WriteLine("MyFile Template Method!!!");
        }
    }
}
