using System.Collections;

namespace _002_List;

public class ArrayList<T> : IEnumerable<T>
{
    public ArrayList() : this(0)
    { }

    public ArrayList(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentException("Error length");
        }

        _items = new T[capacity];
    }

    public ArrayList(ICollection<T> list)
    {
        _items = new T[list.Count];
        Count = list.Count;
        list.CopyTo(_items, 0);
    }

    private T[] _items;

    public int Count { get; private set; }
    public int Capacity
    {
        get { return _items.Length; }
        set
        {
            if (value != _items.Length)
            {
                if (value > 0)
                {
                    T[] newItems = new T[value];
                    Array.Copy(_items, 0, newItems, 0, _items.Length);
                    _items = newItems;
                }
                else
                {
                    _items = new T[0];
                }
            }
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}