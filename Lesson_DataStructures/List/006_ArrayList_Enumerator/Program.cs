namespace _006_ArrayList_Enumerator;

internal class Program
{
    static void Main(string[] args)
    {
        var list1 = new ArrayList<int> { 10, 20, 30 };
        foreach (int item in list1)
        {
            Console.WriteLine(item);
        }

        Console.ReadLine();
    }
}
