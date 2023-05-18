namespace _001_List;

internal class Program
{
    static void Main(string[] args)
    {
        var list = new List<int>(528435456);
        for (int i = 0; i < int.MaxValue; i++)
        {
            list.Add(i);
        }

        Console.ReadLine();
    }
}
