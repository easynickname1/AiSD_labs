namespace lab05;

public class MyDictionary<TKey, TValue>
{
    private struct Entry
    {
        public TKey Key;
        public TValue Value;
    }

    private Entry[] _entries;
    private int _capacity;
    private int _count;

    public MyDictionary()
    {
        _capacity = 16;
        _entries = new Entry[_capacity];
        _count = 0;
    }

    public int Count => _count;

    public void Add(TKey key, TValue value)
    {
        int index = GetIndex(key);
        if (_entries[index].Key != null)
        {
            _entries[index].Value = value;
        }
        else
        {
            _entries[index].Key = key;
            _entries[index].Value = value;
            _count++;
        }
    }

    public bool ContainsKey(TKey key)
    {
        int index = GetIndex(key);
        return _entries[index].Key != null && _entries[index].Key.Equals(key);
    }

    public TValue Get(TKey key)
    {
        int index = GetIndex(key);
        if (_entries[index].Key == null || !_entries[index].Key.Equals(key))
        {
            throw new KeyNotFoundException();
        }
        return _entries[index].Value;
    }

    public bool Remove(TKey key)
    {
        int index = GetIndex(key);
        if (_entries[index].Key != null && _entries[index].Key.Equals(key))
        {
            _entries[index].Key = default(TKey);
            _entries[index].Value = default(TValue);
            _count--;
            return true;
        }
        return false;
    }

    private int GetIndex(TKey key)
    {
        int hashCode = key.GetHashCode();
        return hashCode % _capacity;
    }
}
