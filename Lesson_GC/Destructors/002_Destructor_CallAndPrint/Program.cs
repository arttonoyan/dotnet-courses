namespace _002_Destructor_CallAndPrint;

internal class Program
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 500000; i++)
        {
            var ex = new Example(i);
        }

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
            Console.WriteLine($"Number {_number}. I died...");
        }
    }
}
