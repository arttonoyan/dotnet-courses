namespace _005_ArrayList_Remove;

internal class Program
{
    static void Main(string[] args)
    {
        var list1 = new ArrayList<int> { 10, 20, 30 };
        list1.RemoveAt(1);
        list1.Remove(30);
    }
}
