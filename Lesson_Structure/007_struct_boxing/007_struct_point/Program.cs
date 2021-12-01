using System;
using System.Collections.Generic;

namespace _007_struct_point
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Point(10, 20);
            var p2 = new Point(10, 20);

            if (p1.Equals(p2))
            {
            }

            int code1 = p1.GetHashCode();
            int code2 = p2.GetHashCode();

            var hs = new HashSet<int>();
            hs.Add(10);
            hs.Add(10);
            hs.Add(20);
            hs.Add(10);

            var hs1 = new HashSet<Point>();
            hs1.Add(p1);
            hs1.Add(p2);

            Console.ReadLine();
        }
    }

    struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
            //my = new MyClass();
        }

        public Point(Point p)
        {
            this = p;
            //this.X = p.X;
            //this.Y = p.Y;
        }

        public int X;
        public int Y;
        //public MyClass my;
    }

    class MyClass { }
}
