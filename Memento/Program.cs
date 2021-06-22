using System;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            
            MyRectangle myRectangle = new MyRectangle(10, 20, 100, 200);
            myRectangle.View();
            //
            // memento save
            //
            myRectangle.Save();

            //
            // changed x, width
            //
            myRectangle.X += 5;
            myRectangle.Width += 100;

            myRectangle.View();

            //
            // memento reset
            //
            myRectangle.Undo();
            myRectangle.View();


        }
    }
}
