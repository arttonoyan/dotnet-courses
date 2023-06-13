namespace _006_Destructor_Exception;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Started.");

        for (int i = 0; i < 500000; i++)
        {
            var ex = new Example(i);
        }

        Console.WriteLine("Finished.");

        Console.ReadLine();
    }

    public class Example
    {
        private int _number;
        public Example(int number)
        {
            _number = number;
        }

        ~Example()
        {
            throw new Exception();
            Console.WriteLine($"Number {_number}. I died...");

            //try
            //{
            //
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine($"My number is {_number}. I died...");
            //}
        }
    }
}
