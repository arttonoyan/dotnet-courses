namespace _004_Destructor_LongRunningDestructor;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Started");

        for (int i = 0; i < 500000; i++)
        {
            var ex = new Example(i);
        }

        Console.WriteLine("Finished");

        Console.ReadLine();
    }

    public class Example
    {
        private readonly int _number;
        public Example(int number)
        {
            _number = number;
        }

        ~Example()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"Number {_number}. I died...");
            }
        }
    }
}
