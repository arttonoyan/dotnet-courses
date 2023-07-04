using System.Collections.Concurrent;

namespace _001_ConcurrentDictionary;

//https://learn.microsoft.com/en-us/dotnet/api/system.collections.concurrent.concurrentdictionary-2?view=net-7.0
internal class Program
{
    static void Main(string[] args)
    {
        var dict = new ConcurrentDictionary<int, string>();

        // TryAdd returns false if the key already exists
        bool res1 = dict.TryAdd(1, "First");
        bool res2 = dict.TryAdd(2, "Second");
        bool res3 = dict.TryAdd(1, "First");

        // GetOrAdd returns the value if the key already exists, otherwise adds the key and value and returns the value
        string valueFirst = dict.GetOrAdd(1, "First");
        string valueThird = dict.GetOrAdd(3, "Third");

        // AddOrUpdate Adds a key/value pair to the ConcurrentDictionary if the key does not already exist,
        // or updates a key/value pair in the ConcurrentDictionary if the key already exists and returns the new value
        string valueFourth = dict.AddOrUpdate(4, "Fourth", (key, oldValue) => "Fourth");
        string valueFifthBad = dict.AddOrUpdate(5, "Fifth BAD", (key, oldValue) => "Fourth");
        string valueFifth = dict.AddOrUpdate(5, "Fifth BAD", (key, oldValue) => "Fifth");
        // AddOrUpdate second overload method
        string value1 = dict.AddOrUpdate(6, key =>
        {
            return $"Sixth {key}";
        }, (key, oldValue) =>
        {
            return "Sixth";
        });
        string value2 = dict.AddOrUpdate(6, key =>
        {
            return $"Sixth {key}";
        }, (key, oldValue) =>
        {
            return "Sixth";
        });

        // AddOrUpdate third overload method
        string value3 = dict.AddOrUpdate<long>(7, (key, arg) =>
        {
            return $"Seventh {key}";
        }, (key, oldValue, arg) =>
        {
            return "Seventh";
        }, factoryArgument: 10);

        string value4 = dict.AddOrUpdate<long>(7, (key, arg) =>
        {
            return $"Seventh {key}";
        }, (key, oldValue, arg) =>
        {
            return "Seventh";
        }, factoryArgument: 10);

        // ContainsKey returns true if the key exists
        if (dict.ContainsKey(1))
        {
            Console.WriteLine($"Key 1 exists with value {dict[1]}");
        }

        // TryGetValue returns true if the key exists and sets the out parameter to the value,
        // otherwise returns false and sets the out parameter to the default value
        if (dict.TryGetValue(1, out var value))
        {
            Console.WriteLine($"Key 1 exists with value {value}");
        }

        // Operations acquiring all locks
        bool isEmpty = dict.IsEmpty;
        Console.WriteLine($"Dictionary isEmpty: {isEmpty}");

        int count = dict.Count;
        Console.WriteLine($"Dictionary Count: {count}");
    }
}
