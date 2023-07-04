namespace _002_ConcurrentDictionary_SourceCode;

internal class Program
{
    static void Main(string[] args)
    {
        var dict = new MyConcurrentDictionary<int, string>();
        bool res1 = dict.TryAdd(1, "First");
        bool res2 = dict.TryAdd(2, "Second");
        bool res3 = dict.TryAdd(1, "First");
    }
}
