namespace lab05;

public class MyList<T>
{
    private Node<T> _head;
    private int _count;

    private class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public MyList()
    {
        _head = null;
        _count = 0;
    }

    public int Count
    {
        get { return _count; }
    }

    public void Add(T item)
    {
        Node<T> newNode = new Node<T>(item);

        if (_head == null)
        {
            _head = newNode;
        }
        else
        {
            Node<T> current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }

        _count++;
    }

    public T GetItem(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }

        Node<T> current = _head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }

        return current.Data;
    }
}
