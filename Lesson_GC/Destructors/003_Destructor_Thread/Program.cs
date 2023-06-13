namespace _003_Destructor_Thread;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Main thread Id is {Thread.CurrentThread.ManagedThreadId}");

        Console.WriteLine("Enter any key to continue.");
        Console.ReadLine();

        for (int i = 0; i < 500000; i++)
        {
            var ex = new Example(i);
        }

        Console.WriteLine("Finished.");
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
            Console.WriteLine($"Number {_number}. Thread Id is {Thread.CurrentThread.ManagedThreadId} I died...");
        }
    }
}
