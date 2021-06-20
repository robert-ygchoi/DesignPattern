using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // root
            // ↳ first
            //   ↳ first_child
            //      ↳ first_child_first_file
            //   ↳ first_first_file
            // ↳ second
            // ↳ root_first_file
            // ↳ root_second_file
            MyDirectory root = new MyDirectory("root_directory");
            MyDirectory first = new MyDirectory("first_directory");
            MyDirectory second = new MyDirectory("second_directory");
            MyDirectory first_child = new MyDirectory("first_child_directory");

            MyFile root_first_file = new MyFile("root_first_file");
            MyFile root_second_file = new MyFile("root_second_file");
            MyFile first_first_file = new MyFile("first_first_file");
            MyFile first_child_first_file = new MyFile("first_child_first_file");

            root.AddChild(first);
            first.AddChild(first_child);
            first.AddChild(first_first_file);
            first_child.AddChild(first_child_first_file);
            root.AddChild(second);
            root.AddChild(root_first_file);
            root.AddChild(root_second_file);

            root.Show();

            Console.Read();


        }
    }
}
