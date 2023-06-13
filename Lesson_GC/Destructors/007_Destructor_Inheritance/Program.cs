namespace _007_Destructor_Inheritance;

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
}

public class BaseExample
{
    protected int _number;
    public BaseExample(int number)
    {
        _number = number;
    }

    ~BaseExample()
    {
        Console.WriteLine($"BASE CLASS DESTRUCTOR NUMBER {_number}.");
        //base.Finalize();
    }
}
public class Example : BaseExample
{
    public Example(int number) : base(number)
    {
    }

    ~Example()
    {
        Console.WriteLine($"Number {_number}. I died...");
    }
}
