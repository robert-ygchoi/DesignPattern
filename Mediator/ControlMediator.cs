using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{ 
    internal interface ICommand
    {
        void Exec();
    }

    internal abstract class Control
    {
        protected ControlMediator ControlMediator { get; set; }

        protected Control(ControlMediator controlMediator)
        {
            ControlMediator = controlMediator;
        }
        public void Enabled(bool enabled)
        {
            Console.WriteLine($"{this.GetType().Name} Enabled {enabled}");
        }
    }

    internal class Button : Control, ICommand
    {
        public Button(ControlMediator controlMediator) : base(controlMediator)
        {
            controlMediator.AddButton(this);
        }

        public void Exec()
        {
            ControlMediator.Search();
        }
    }
    internal class ListView : Control, ICommand
    {
        public ListView(ControlMediator controlMediator) : base(controlMediator)
        {
            controlMediator.AddListView(this);
        }

        public void Exec()
        {
            ControlMediator.View();
        }
    }

    internal interface IMediator
    {
        void Search();
        void View();

        void AddButton(Button button);
        void AddListView(ListView listView);
    }

    

    internal class ControlMediator : IMediator
    {
        Button Button { get; set; }
        ListView ListView { get; set; }
        public void AddButton(Button button)
        {
            Button = button;
        }

        public void AddListView(ListView listView)
        {
            ListView = listView;
        }

        public void Search()
        {
            Button.Enabled(true);
            ListView.Enabled(false);
            Console.WriteLine("searching!!!");
        }

        public void View()
        {
            Button.Enabled(false);
            ListView.Enabled(true);
            Console.WriteLine("viewing!!!");
        }
    }
}
