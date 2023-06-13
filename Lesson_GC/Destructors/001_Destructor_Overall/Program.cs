namespace _001_Destructor_Overall;

internal class Program
{
    static void Main(string[] args)
    {
        var ex = new Example();

        //ex.Finalize();
    }

    public struct ExampleStruct
    {
        // Can't have a destructor in a struct
        //~ExampleStruct()
        //{
        //    File.WriteAllText("destructor.txt", "I died...");
        //}
    }

    public class Example
    {
        // Can't have a destructor with arguments
        //~Example(int arg)
        //{
        //    File.WriteAllText("destructor.txt", "I died...");
        //}

        // Can't have a static destructor
        //static ~Example()
        //{
        //    File.WriteAllText("destructor.txt", "I died...");
        //}

        // Can't have a destructor with access modifier
        //public ~Example()
        //{
        //    File.WriteAllText("destructor.txt", "I died...");
        //}

        ~Example()
        {
            File.WriteAllText("destructor.txt", "I died...");
        }
    }
}
