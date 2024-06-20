namespace lab05._2;

internal class TrainingNutritionMenuLinkedList<T>
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

    public TrainingNutritionMenuLinkedList()
    {
        _head = null;
        _count = 0;
    }

    public int Count => _count;

    public bool IsEmpty => _count == 0;

    public void Push(T product)
    {
        Node<T> newNode = new Node<T>(product);
        newNode.Next = _head;
        _head = newNode;
        _count++;
    }

    public T? Pop()
    {
        if (IsEmpty)
        {
            Console.WriteLine("В меню пусто");
            return default;
        }

        T product = _head.Data;
        _head = _head.Next;
        _count--;
        return product;
    }

    public T? Peek()
    {
        if (IsEmpty)
        {
            Console.WriteLine("В меню пусто");
            return default;
        }
        return _head.Data;
    }
}
