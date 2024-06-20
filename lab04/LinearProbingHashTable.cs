namespace lab04;

using System;
using System.Text;

public class LinearProbingHashTable<TKey, TValue>
{
    private const int DefaultCapacity = 16;

    private int _capacity;
    private int _size;
    private KeyValuePair<TKey, TValue>[] _table;

    public LinearProbingHashTable() : this(DefaultCapacity) { }

    public LinearProbingHashTable(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException("Capacity must be greater than 0.");

        _capacity = capacity;
        _table = new KeyValuePair<TKey, TValue>[_capacity];
    }
    public int Capacity => _capacity;

    public int Size => _size;

    public int Add(TKey key, TValue value)
    {
        if (_size >= _capacity / 2)
            Resize(_capacity * 2);

        int index = GetHash(key);
        int startIndex = index;
        int coll = 0;

        while (_table[index].Key != null && !_table[index].Key.Equals(default(TKey)))
        {
            if (_table[index].Key.Equals(key))
            {
                coll++;
                index = (index + 1) % _capacity;

                // Если вернулись к начальному индексу, таблица заполнена
                if (index == startIndex)
                {
                    throw new InvalidOperationException("Хэш-таблица заполнена.");
                }

                continue;
            }

            index = (index + 1) % _capacity;

            // Если вернулись к начальному индексу, таблица заполнена
            if (index == startIndex)
            {
                throw new InvalidOperationException("Хэш-таблица заполнена.");
            }
        }

        _table[index] = new KeyValuePair<TKey, TValue>(key, value);
        _size++;
        return coll;
    }

    public bool ContainsKey(TKey key)
    {
        int index = GetHash(key);
        while (_table[index].Key != null && !_table[index].Key.Equals(default(TKey)))
        {
            if (_table[index].Key.Equals(key))
                return true;

            index = (index + 1) % _capacity;
        }

        return false;
    }

    public TValue Get(TKey key)
    {
        int index = GetHash(key);
        while (_table[index].Key != null && !_table[index].Key.Equals(default(TKey)))
        {
            if (_table[index].Key.Equals(key))
                return _table[index].Value;

            index = (index + 1) % _capacity;
        }

        Console.WriteLine($"Ключ '{key}' не найден.");
        return default(TValue);
    }

    private void Resize(int newCapacity)
    {
        LinearProbingHashTable<TKey, TValue> newTable = new LinearProbingHashTable<TKey, TValue>(newCapacity);
        foreach (var kvp in _table)
        {
            if (kvp.Key != null && !kvp.Key.Equals(default(TKey)))
            {
                newTable.Add(kvp.Key, kvp.Value);
            }
        }

        _capacity = newCapacity;
        _table = newTable._table;
    }

    private int GetHash(TKey key)
    {
        return Math.Abs(key.GetHashCode() % _capacity);
    }

    public void PrintHashTable()
    {
        Console.WriteLine("Хэш-таблица:");
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < _capacity; i++)
        {
            sb.Append($"[{i}] -> ");
            if (_table[i].Key != null && !_table[i].Key.Equals(default(TKey)))
            {
                sb.Append($"{{ {_table[i].Key}, {_table[i].Value} }}");
            }
            else
            {
                sb.Append("Пусто");
            }
            sb.AppendLine();
        }
        Console.WriteLine(sb.ToString());
    }

    public double GetLoadFactor()
    {
        return (double)_size / _capacity;
    }
}
