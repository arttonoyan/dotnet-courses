using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace _003_LinkedList_Benchmark;

internal class Program
{
    static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<ListBenchmarker>();
    }
}

[MemoryDiagnoser]
public class ListBenchmarker
{
    [Params(1000, 10000)]
    public int TotalCount { get; set; }

    [Benchmark]
    public void ListAdd()
    {
        var list = new List<int>();
        for (int i = 0; i < TotalCount; i++)
        {
            list.Add(i);
        }
    }

    [Benchmark]
    public void ListAddCapacity()
    {
        var list = new List<int>(TotalCount);
        for (int i = 0; i < TotalCount; i++)
        {
            list.Add(i);
        }
    }

    [Benchmark]
    public void LinkedListAdd()
    {
        var list = new LinkedList<int>();
        for (int i = 0; i < TotalCount; i++)
        {
            list.AddLast(i);
        }
    }

    [Benchmark]
    public void ListInsert0()
    {
        var list = new List<int>(TotalCount);
        for (int i = 0; i < TotalCount; i++)
        {
            list.Insert(0, i);
        }
    }

    [Benchmark]
    public void LinkedListInsert0()
    {
        var list = new LinkedList<int>();
        for (int i = 0; i < TotalCount; i++)
        {
            list.AddFirst(i);
        }
    }
}
