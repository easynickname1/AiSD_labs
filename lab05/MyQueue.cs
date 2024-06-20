namespace lab05;

public class MyQueue<T>
{
    private T[] _items;
    private int _front;
    private int _rear;
    private int _count;

    public MyQueue()
    {
        _items = new T[4];
        _front = 0;
        _rear = 0;
        _count = 0;
    }

    public int Count => _count;

    public void Enqueue(T item)
    {
        if (_count == _items.Length)
        {
            Resize();
        }

        _items[_rear] = item;
        _rear = (_rear + 1) % _items.Length;
        _count++;
    }

    public T Dequeue()
    {
        if (_count == 0)
        {
            throw new InvalidOperationException("Очередь пуста.");
        }

        T item = _items[_front];
        _front = (_front + 1) % _items.Length;
        _count--;
        return item;
    }

    public T Peek()
    {
        if (_count == 0)
        {
            throw new InvalidOperationException("Очередь пуста.");
        }
        return _items[_front];
    }

    private void Resize()
    {
        T[] newItems = new T[_items.Length * 2];
        for (int i = 0; i < _count; i++)
        {
            newItems[i] = _items[(_front + i) % _items.Length];
        }
        _items = newItems;
        _front = 0;
        _rear = _count;
    }
}
