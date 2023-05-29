namespace _003_HashSet;

internal class Program
{
    static void Main(string[] args)
    {
        var set = new HashSet<int>();
        set.Add(10);
        set.Add(20);
        set.Add(10);
        set.Add(30);
        set.Add(10);
        set.Add(50);

        set.ExceptWith(new List<int>(2) { 10, 20 });
    }
}
