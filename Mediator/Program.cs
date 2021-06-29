using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlMediator controlMediator = new ControlMediator();

            ListView listView = new ListView(controlMediator);
            Button button = new Button(controlMediator);

            listView.Exec();
            Console.WriteLine("===");
            button.Exec();

            Console.ReadLine();
        }
    }
}
