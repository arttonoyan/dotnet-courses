namespace _002_HashSet;

//https://referencesource.microsoft.com/#System.Core/System/Collections/Generic/HashSet.cs,b2182f2377bcd789
internal class Program
{
    static void Main(string[] args)
    {
        var set = new MyHashSet<int>();
        set.Add(50);
        set.Add(-50);
        set.Add(-10);
        set.Add(-20);
        set.Add(20);
        set.Add(10);
        set.Add(30);
        set.Add(10);
        set.Add(50);

        set.Contains(20);

        foreach (var item in set)
        {
            Console.WriteLine(item);
        }

        Console.ReadLine();
        set.Remove(20);
    }
}
