using System.Collections;

namespace _003_Queue;

public class MyQueue<T> : IEnumerable<T>, ICollection, IReadOnlyCollection<T>
{
    private T[] _array;
    private int _head;       // First valid element in the queue
    private int _tail;       // Last valid element in the queue
    private int _size;       // Number of elements.

    private const int _minimumGrow = 4;
    private const int _growFactor = 200;  // double each time

    private static T[] _emptyArray = new T[0];

    public MyQueue()
    {
        _array = _emptyArray;
    }

    public MyQueue(int capacity)
    {
        _array = new T[capacity];
        _head = 0;
        _tail = 0;
        _size = 0;
    }

    public int Count => _size;

    #region ICollection

    object ICollection.SyncRoot => false;

    bool ICollection.IsSynchronized => false;

    #endregion

    public void Enqueue(T item)
    {
        if (_size == _array.Length)
        {
            int newcapacity = (int)((long)_array.Length * (long)_growFactor / 100);
            if (newcapacity < _array.Length + _minimumGrow)
            {
                newcapacity = _array.Length + _minimumGrow;
            }
            SetCapacity(newcapacity);
        }

        _array[_tail] = item;
        _tail = (_tail + 1) % _array.Length;
        _size++;
    }

    public T Dequeue()
    {
        if (_size == 0)
            throw new InvalidOperationException("....");

        T removed = _array[_head];
        _array[_head] = default;
        _head = (_head + 1) % _array.Length;
        _size--;
        return removed;
    }

    public T Peek()
    {
        if (_size == 0)
            throw new InvalidOperationException();

        return _array[_head];
    }

    private void SetCapacity(int capacity)
    {
        T[] newarray = new T[capacity];
        if (_size > 0)
        {
            if (_head < _tail)
            {
                Array.Copy(_array, _head, newarray, 0, _size);
            }
            else
            {
                Array.Copy(_array, _head, newarray, 0, _array.Length - _head);
                Array.Copy(_array, 0, newarray, _array.Length - _head, _tail);
            }
        }

        _array = newarray;
        _head = 0;
        _tail = (_size == capacity) ? 0 : _size;
    }

    public bool Contains(T item)
    {
        int index = _head;
        int count = _size;

        var comparer = EqualityComparer<T>.Default;
        while (count-- > 0)
        {
            if (item == null)
            {
                if (_array[index] == null)
                    return true;
            }
            else if (_array[index] != null && comparer.Equals(_array[index], item))
            {
                return true;
            }
            index = (index + 1) % _array.Length;
        }

        return false;
    }

    public T[] ToArray()
    {
        T[] arr = new T[_size];
        if (_size == 0)
            return arr;

        if (_head < _tail)
        {
            Array.Copy(_array, _head, arr, 0, _size);
        }
        else
        {
            Array.Copy(_array, _head, arr, 0, _array.Length - _head);
            Array.Copy(_array, 0, arr, _array.Length - _head, _tail);
        }

        return arr;
    }

    public void TrimExcess()
    {
        int threshold = (int)(((double)_array.Length) * 0.9);
        if (_size < threshold)
        {
            SetCapacity(_size);
        }
    }

    public void CopyTo(Array array, int arrayIndex)
    {
        if (array == null)
            throw new ArgumentNullException("....");

        if (arrayIndex < 0 || arrayIndex > array.Length)
            throw new ArgumentOutOfRangeException("....");

        int arrayLen = array.Length;
        if (arrayLen - arrayIndex < _size)
            throw new ArgumentException("....");

        int numToCopy = (arrayLen - arrayIndex < _size) ? (arrayLen - arrayIndex) : _size;
        if (numToCopy == 0)
            return;

        int firstPart = (_array.Length - _head < numToCopy) ? _array.Length - _head : numToCopy;
        Array.Copy(_array, _head, array, arrayIndex, firstPart);
        numToCopy -= firstPart;
        if (numToCopy > 0)
        {
            Array.Copy(_array, 0, array, arrayIndex + _array.Length - _head, numToCopy);
        }
    }

    public void Clear()
    {
        if (_head < _tail)
            Array.Clear(_array, _head, _size);
        else
        {
            Array.Clear(_array, _head, _array.Length - _head);
            Array.Clear(_array, 0, _tail);
        }

        _head = 0;
        _tail = 0;
        _size = 0;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private T GetElement(int i)
    {
        return _array[(_head + i) % _array.Length];
    }

    public struct Enumerator : IEnumerator<T>
    {
        private readonly MyQueue<T> _q;
        private int _index;   // -1 = not started, -2 = ended/disposed
        private T _currentElement;

        internal Enumerator(MyQueue<T> q)
        {
            _q = q;
            _index = -1;
            _currentElement = default;
        }

        public bool MoveNext()
        {
            if (_index == -2)
                return false;

            _index++;

            if (_index == _q._size)
            {
                _index = -2;
                _currentElement = default;
                return false;
            }

            _currentElement = _q.GetElement(_index);
            return true;
        }

        public T Current
        {
            get
            {
                if (_index < 0)
                {
                    if (_index == -1)
                        throw new InvalidOperationException("....");
                    else
                        throw new InvalidOperationException("....");
                }
                return _currentElement;
            }
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            _index = -2;
            _currentElement = default;
        }

        void IEnumerator.Reset()
        {
            _index = -1;
            _currentElement = default;
        }
    }
}
