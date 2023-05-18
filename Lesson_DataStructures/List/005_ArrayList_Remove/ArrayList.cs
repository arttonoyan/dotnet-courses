using System.Collections;

namespace _005_ArrayList_Remove;

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
    private const int _defaultCapacity = 4;

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

    public void Add(T item)
    {
        if (_items.Length == Count)
        {
            EnsureCapacity();
        }

        _items[Count++] = item;
    }

    public void Insert(int index, T item)
    {
        if (index > Count)
            throw new IndexOutOfRangeException();

        if (_items.Length == Count)
            EnsureCapacity();

        Array.Copy(_items, index, _items, index + 1, Count - index);

        _items[index] = item;
        Count++;
    }

    public int IndexOf(T item)
    {
        return Array.IndexOf(_items, item, 0, _items.Length);
    }

    public void RemoveAt(int index)
    {
        if (index >= Count)
            throw new IndexOutOfRangeException();

        Count--;
        if (index < Count)
        {
            Array.Copy(_items, index + 1, _items, index, Count - index);
        }
        _items[Count] = default(T);
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);
        if (index >= 0)
        {
            RemoveAt(index);
            return true;
        }

        return false;
    }

    private void EnsureCapacity()
    {
        int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
        Capacity = newCapacity;
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