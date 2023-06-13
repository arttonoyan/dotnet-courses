namespace _004_GC_Exception;

internal class Program
{
    static void Main(string[] args)
    {
        // 95MB * 1000 = 93GB
        var bigExamples = new BigExample[1000];

        Console.WriteLine(GC.GetTotalMemory(false) / 1024 + "KB");
        try
        {
            for (int i = 0; i < bigExamples.Length; i++)
            {
                bigExamples[i] = new BigExample();
            }
        }
        catch (OutOfMemoryException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(GC.GetTotalMemory(false) / 1024 + "KB");
        }

        Console.ReadLine();
    }
}

public class BigExample
{
    // 100000000 byte = 97656 KB = 95 MB
    byte[] arr = new byte[1000000000];

    public BigExample()
    {
        Console.WriteLine("I was born...");
    }
    ~BigExample()
    {
        Console.WriteLine("I died...");
    }
}
