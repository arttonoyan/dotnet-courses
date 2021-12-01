using System;

namespace _011_struct_boxing_point
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point(10, 20);
            object obj = p;

            p.X = 0;
            p.Y = 0;

            Point p1 = (Point)obj;
            p1.Print();
            Console.ReadLine();
        }
    }

    struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(Point p)
        {
            this = p;
        }

        public int X;
        public int Y;

        public void Print()
        {
            Console.WriteLine("X: {0}, Y: {1}", X, Y);
        }
    }
}
