using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{

    internal class MyRectangle
    {
        private MyRectangle Memento { get; set; }
        internal int X { get; set; }
        internal int Y { get; set; }
        internal int Width { get; set; }
        internal int Height { get; set; }

        public MyRectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void View()
        {
            Console.WriteLine($"X: {X} Y: {Y} Width: {Width} Height: {Height}");
        }
            
        public void Save()
        {
            Memento = new MyRectangle(this.X, this.Y, this.Width, this.Height);
        }

        public void Undo()
        {
            if (Memento is null)
                return;

            Changed(Memento);

            Memento = null;
        }

        public void Changed(MyRectangle memento)
        {
            this.X = memento.X;
            this.Y = memento.Y;
            this.Width = memento.Width;
            this.Height = memento.Height;
        }
    }
}
