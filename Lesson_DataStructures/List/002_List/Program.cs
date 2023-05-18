namespace _002_List;

internal class Program
{
    static void Main(string[] args)
    {
        var list1 = new ArrayList<int>(10);

        var coll = new List<int> { 10, 20, 30 };
        var list2 = new ArrayList<int>(coll);
    }
}
