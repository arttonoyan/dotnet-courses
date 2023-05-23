using System.Collections;

namespace _003_Stack;

//https://referencesource.microsoft.com/#System/compmod/system/collections/generic/stack.cs,c5371bef044c6ab6
public class MyStack<T> : IEnumerable<T>, ICollection, IReadOnlyCollection<T>
{
    private T[] _array;     // Storage for stack elements
    private int _size;      // Number of items in the stack.

    private const int _defaultCapacity = 4;
    static readonly T[] _emptyArray = new T[0];

    public MyStack()
    {
        _array = _emptyArray;
        _size = 0;
    }

    public MyStack(int capacity)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException("...");

        _array = new T[capacity];
        _size = 0;
    }

    public int Count => _size;

    #region ICollection
    object ICollection.SyncRoot => false;

    bool ICollection.IsSynchronized => false;

    #endregion

    public T Peek()
    {
        if (_size == 0)
            throw new InvalidOperationException("...");

        return _array[_size - 1];
    }

    public T Pop()
    {
        if (_size == 0)
            throw new InvalidOperationException("...");

        T item = _array[--_size];
        _array[_size] = default; // Free memory quicker.
        return item;
    }

    public void Push(T item)
    {
        if (_size == _array.Length)
        {
            T[] newArray = new T[(_array.Length == 0) ? _defaultCapacity : 2 * _array.Length];
            Array.Copy(_array, 0, newArray, 0, _size);
            _array = newArray;
        }
        _array[_size++] = item;
    }

    public void Clear()
    {
        Array.Clear(_array, 0, _size);
        _size = 0;
    }

    public bool Contains(T item)
    {
        int count = _size;

        var comparer = EqualityComparer<T>.Default;
        while (count-- > 0)
        {
            if (item == null)
            {
                if (_array[count] == null)
                    return true;
            }
            else if (_array[count] != null && comparer.Equals(_array[count], item))
            {
                return true;
            }
        }
        return false;
    }

    public void CopyTo(Array array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException("...");

        if (arrayIndex < 0 || arrayIndex > array.Length)
            throw new ArgumentOutOfRangeException("...");

        if (array.Length - arrayIndex < _size)
            throw new ArgumentException("...");

        Array.Copy(_array, 0, array, arrayIndex, _size);
        Array.Reverse(array, arrayIndex, _size);
    }

    public void TrimExcess()
    {
        int threshold = (int)(((double)_array.Length) * 0.9);
        if (_size < threshold)
        {
            T[] newarray = new T[_size];
            Array.Copy(_array, 0, newarray, 0, _size);
            _array = newarray;
        }
    }

    public T[] ToArray()
    {
        T[] objArray = new T[_size];
        int i = 0;
        while (i < _size)
        {
            objArray[i] = _array[_size - i - 1];
            i++;
        }
        return objArray;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public struct Enumerator : IEnumerator<T>
    {
        private MyStack<T> _stack;
        private int _index;

        internal Enumerator(MyStack<T> stack)
        {
            _stack = stack;
            _index = -2;
            Current = default;
        }

        public T Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            bool retval;
            if (_index == -2)
            {
                // First call to enumerator.
                _index = _stack._size - 1;
                retval = _index >= 0;
                if (retval)
                    Current = _stack._array[_index];
                return retval;
            }
            if (_index == -1)
            {
                // End of enumeration.
                return false;
            }

            retval = --_index >= 0;
            if (retval)
                Current = _stack._array[_index];
            else
                Current = default;
            return retval;
        }

        public void Dispose()
        {
            _index = -1;
        }

        void IEnumerator.Reset()
        {
            _index = -2;
            Current = default;
        }
    }
}
