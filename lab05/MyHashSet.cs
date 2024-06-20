namespace lab05;

using System;
using System.Text;

public class MyHashSet<TKey, TValue>
{
    private const int DefaultCapacity = 16;

    private class Node
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public Node Next { get; set; }

        public Node(TKey key, TValue value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }

    private Node[] _table;
    private int _capacity;
    private int _size;

    public MyHashSet() : this(DefaultCapacity) { }

    public MyHashSet(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException("Capacity must be greater than 0.");

        _capacity = capacity;
        _table = new Node[_capacity];
    }

    public int Size => _size;

    public void Add(TKey key, TValue value)
    {
        int index = GetHash(key);

        Node newNode = new Node(key, value);

        if (_table[index] == null)
        {
            _table[index] = newNode;
        }
        else
        {
            Node current = _table[index];
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNode;
        }
        _size++;
    }

    public bool ContainsKey(TKey key)
    {
        int index = GetHash(key);
        Node current = _table[index];

        while (current != null)
        {
            if (current.Key.Equals(key))
                return true;
            current = current.Next;
        }

        return false;
    }

    public TValue Get(TKey key)
    {
        int index = GetHash(key);
        Node current = _table[index];

        while (current != null)
        {
            if (current.Key.Equals(key))
                return current.Value;
            current = current.Next;
        }

        throw new KeyNotFoundException($"Key '{key}' not found.");
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
            sb.Append($"[{i}]");
            Node current = _table[i];
            while (current != null)
            {
                sb.Append($" -> {{ {current.Key}, {current.Value} }} ");
                current = current.Next;
            }
            if (current == null)
            {
                sb.Append(" Пусто");
            }
            sb.AppendLine();
        }
        Console.WriteLine(sb.ToString());
    }
}
