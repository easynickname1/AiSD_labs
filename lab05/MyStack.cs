namespace lab05;

public class MyStack<T>
{
    private T[] _items;
    private int _top;

    public MyStack()
    {
        _items = new T[4];
        _top = -1;
    }

    public int Count => _top + 1;

    public void Push(T item)
    {
        if (_top == _items.Length - 1)
        {
            Resize();
        }

        _top++;
        _items[_top] = item;
    }

    public T Pop()
    {
        if (_top == -1)
        {
            throw new InvalidOperationException("Стек пуст.");
        }

        T item = _items[_top];
        _top--;
        return item;
    }

    public T Peek()
    {
        if (_top == -1)
        {
            throw new InvalidOperationException("Стек пуст.");
        }
        return _items[_top];
    }

    private void Resize()
    {
        T[] newItems = new T[_items.Length * 2];
        Array.Copy(_items, newItems, _items.Length);
        _items = newItems;
    }
}
