using System.Collections;

namespace _002_HashSet;

public class MyHashSet<T> : ICollection<T>, IReadOnlyCollection<T>
{
    // store lower 31 bits of hash code
    private const int Lower31BitMask = 0x7FFFFFFF;
    private const int StackAllocThreshold = 100;
    private const int ShrinkThreshold = 3;

    private int[] m_buckets;
    private Slot[] m_slots;
    private int m_count;
    private int m_lastIndex;
    private int m_freeList;
    private IEqualityComparer<T> m_comparer;

    public int Count => m_count;

    bool ICollection<T>.IsReadOnly => false;

    #region ctors
    public MyHashSet()
        : this(EqualityComparer<T>.Default) { }

    public MyHashSet(IEqualityComparer<T> comparer)
    {
        if (comparer == null)
        {
            comparer = EqualityComparer<T>.Default;
        }

        this.m_comparer = comparer;
        m_lastIndex = 0;
        m_count = 0;
        m_freeList = -1;
    }

    public MyHashSet(int capacity, IEqualityComparer<T> comparer)
        : this(comparer)
    {
        if (capacity < 0)
            throw new ArgumentOutOfRangeException("capacity");

        if (capacity > 0)
        {
            Initialize(capacity);
        }
    }

    private void Initialize(int capacity)
    {
        int size = HashHelpers.GetPrime(capacity);

        m_buckets = new int[size];
        m_slots = new Slot[size];
    }
    #endregion

    /// <summary>
    /// Add item to this HashSet. Returns bool indicating whether item was added (won't be 
    /// added if already present)
    /// </summary>
    /// <param name="item"></param>
    /// <returns>true if added, false if already present</returns>
    public bool Add(T item)
    {
        return AddIfNotPresent(item);
    }

    private bool AddIfNotPresent(T value)
    {
        if (m_buckets == null)
        {
            Initialize(0);
        }

        int hashCode = InternalGetHashCode(value);
        int bucket = hashCode % m_buckets.Length;
        for (int i = m_buckets[bucket] - 1; i >= 0; i = m_slots[i].next)
        {
            if (m_slots[i].hashCode == hashCode && m_comparer.Equals(m_slots[i].value, value))
            {
                return false;
            }
        }

        int index;
        if (m_freeList >= 0)
        {
            index = m_freeList;
            m_freeList = m_slots[index].next;
        }
        else
        {
            if (m_lastIndex == m_slots.Length)
            {
                IncreaseCapacity();
                // this will change during resize
                bucket = hashCode % m_buckets.Length;
            }
            index = m_lastIndex;
            m_lastIndex++;
        }
        m_slots[index].hashCode = hashCode;
        m_slots[index].value = value;
        m_slots[index].next = m_buckets[bucket] - 1;
        m_buckets[bucket] = index + 1;
        m_count++;

        return true;
    }

    private int InternalGetHashCode(T item)
    {
        if (item == null)
        {
            return 0;
        }
        return m_comparer.GetHashCode(item) & Lower31BitMask;
    }

    private void IncreaseCapacity()
    {
        int newSize = HashHelpers.ExpandPrime(m_count);
        if (newSize <= m_count)
        {
            throw new ArgumentException("...");
        }

        // Able to increase capacity; copy elements to larger array and rehash
        SetCapacity(newSize, false);
    }

    private void SetCapacity(int newSize, bool forceNewHashCodes)
    {
        Slot[] newSlots = new Slot[newSize];
        if (m_slots != null)
        {
            Array.Copy(m_slots, 0, newSlots, 0, m_lastIndex);
        }

        if (forceNewHashCodes)
        {
            for (int i = 0; i < m_lastIndex; i++)
            {
                if (newSlots[i].hashCode != -1)
                {
                    newSlots[i].hashCode = InternalGetHashCode(newSlots[i].value);
                }
            }
        }

        int[] newBuckets = new int[newSize];
        for (int i = 0; i < m_lastIndex; i++)
        {
            int bucket = newSlots[i].hashCode % newSize;
            newSlots[i].next = newBuckets[bucket] - 1;
            newBuckets[bucket] = i + 1;
        }
        m_slots = newSlots;
        m_buckets = newBuckets;
    }

    private int InternalIndexOf(T item)
    {
        int hashCode = InternalGetHashCode(item);
        for (int i = m_buckets[hashCode % m_buckets.Length] - 1; i >= 0; i = m_slots[i].next)
        {
            if ((m_slots[i].hashCode) == hashCode && m_comparer.Equals(m_slots[i].value, item))
            {
                return i;
            }
        }
        // wasn't found
        return -1;
    }

    public bool Remove(T item)
    {
        if (m_buckets != null)
        {
            int hashCode = InternalGetHashCode(item);
            int bucket = hashCode % m_buckets.Length;
            int last = -1;
            for (int i = m_buckets[bucket] - 1; i >= 0; last = i, i = m_slots[i].next)
            {
                if (m_slots[i].hashCode == hashCode && m_comparer.Equals(m_slots[i].value, item))
                {
                    if (last < 0)
                    {
                        // first iteration; update buckets
                        m_buckets[bucket] = m_slots[i].next + 1;
                    }
                    else
                    {
                        // subsequent iterations; update 'next' pointers
                        m_slots[last].next = m_slots[i].next;
                    }
                    m_slots[i].hashCode = -1;
                    m_slots[i].value = default(T);
                    m_slots[i].next = m_freeList;

                    m_count--;
                    if (m_count == 0)
                    {
                        m_lastIndex = 0;
                        m_freeList = -1;
                    }
                    else
                    {
                        m_freeList = i;
                    }
                    return true;
                }
            }
        }
        // either m_buckets is null or wasn't found
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    void ICollection<T>.Add(T item)
    {
        Add(item);
    }

    public void Clear()
    {
        if (m_lastIndex > 0)
        {
            // clear the elements so that the gc can reclaim the references.
            // clear only up to m_lastIndex for m_slots 
            Array.Clear(m_slots, 0, m_lastIndex);
            Array.Clear(m_buckets, 0, m_buckets.Length);
            m_lastIndex = 0;
            m_count = 0;
            m_freeList = -1;
        }
    }

    public bool Contains(T item)
    {
        if (m_buckets != null)
        {
            int hashCode = InternalGetHashCode(item);
            // see note at "HashSet" level describing why "- 1" appears in for loop
            for (int i = m_buckets[hashCode % m_buckets.Length] - 1; i >= 0; i = m_slots[i].next)
            {
                if (m_slots[i].hashCode == hashCode && m_comparer.Equals(m_slots[i].value, item))
                {
                    return true;
                }
            }
        }
        // either m_buckets is null or wasn't found
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        CopyTo(array, arrayIndex, m_count);
    }

    public void CopyTo(T[] array, int arrayIndex, int count)
    {
        if (array == null)
            throw new ArgumentNullException("array");

        // check array index valid index into array
        if (arrayIndex < 0)
            throw new ArgumentOutOfRangeException("arrayIndex");

        // also throw if count less than 0
        if (count < 0)
            throw new ArgumentOutOfRangeException("count");

        // will array, starting at arrayIndex, be able to hold elements? Note: not
        // checking arrayIndex >= array.Length (consistency with list of allowing
        // count of 0; subsequent check takes care of the rest)
        if (arrayIndex > array.Length || count > array.Length - arrayIndex)
            throw new ArgumentException("...");

        int numCopied = 0;
        for (int i = 0; i < m_lastIndex && numCopied < count; i++)
        {
            if (m_slots[i].hashCode >= 0)
            {
                array[arrayIndex + numCopied] = m_slots[i].value;
                numCopied++;
            }
        }
    }

    internal struct Slot
    {
        internal int hashCode;      // Lower 31 bits of hash code, -1 if unused
        internal int next;          // Index of next entry, -1 if last
        internal T value;
    }

    public struct Enumerator : IEnumerator<T>, System.Collections.IEnumerator
    {
        private MyHashSet<T> set;
        private int index;

        internal Enumerator(MyHashSet<T> set)
        {
            this.set = set;
            index = 0;
            Current = default(T);
        }

        public T Current { get; private set; }

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            while (index < set.m_lastIndex)
            {
                if (set.m_slots[index].hashCode >= 0)
                {
                    Current = set.m_slots[index].value;
                    index++;
                    return true;
                }
                index++;
            }
            index = set.m_lastIndex + 1;
            Current = default(T);
            return false;
        }

        public void Dispose() { }

        void IEnumerator.Reset()
        {
            index = 0;
            Current = default(T);
        }
    }
}
