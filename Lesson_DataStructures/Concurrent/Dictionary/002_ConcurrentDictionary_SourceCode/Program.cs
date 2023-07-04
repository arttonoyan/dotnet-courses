namespace _002_ConcurrentDictionary_SourceCode;

internal class Program
{
    static void Main(string[] args)
    {
        var dict = new MyConcurrentDictionary<int, string>();
        var res1 = dict.TryAdd(1, "First");
    }
}
