using System;

//covariant, contravariant, invariant
namespace _007_Generics
{
    class Program
    {
        static void Main()
        {
            Shape shape = new Rectangle();

            IContainer<Rectangle> container = new Container<Shape>(shape);

            Console.WriteLine(container.ToString());

            Console.ReadKey();
        }
    }

    public abstract class Shape { }
    public class Rectangle : Shape { }

    public interface IContainer<in T>
    {
        T Figure { set; }
    }

    public class Container<T> : IContainer<T>
    {
        private T figure;

        public Container(T figure)
        {
            this.figure = figure;
        }

        public T Figure
        {
            set { figure = value; }
        }

        public override string ToString()
        {
            return figure.GetType().ToString();
        }
    }
}
