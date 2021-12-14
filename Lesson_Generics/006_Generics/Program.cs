using System;

//covariant, contravariant, invariant
namespace _006_Generics
{
    class Program
    {
        static void Main()
        {
            Rectangle rectangle = new Rectangle();

            IContainer<Shape> container = new Container<Rectangle>(rectangle);
            var type = container.GetType();

            Console.WriteLine(container.Figure.ToString());

            // Delay.
            Console.ReadKey();
        }
    }

    public abstract class Shape { }
    public class Rectangle : Shape { }
    public class Triangle : Shape { }

    public interface IContainer<out T>
    {
        T Figure { get; }
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
            get { return figure; }
        }
    }
}
