namespace _004_List_Insert;

internal class Program
{
    static void Main(string[] args)
    {
        var list1 = new ArrayList<int> { 10, 20, 30 };
        list1.Add(40);
        list1.Insert(0, 50);
        list1.Add(60);

        var list2 = new List<int>();
        list2.Capacity = 10;

        if (list2.Contains(10))
        {

        }
    }
}
