namespace lab01;

public class TrainingNutritionMenu<T>
{
    public T[] products;
    int count;

    public TrainingNutritionMenu()
    {
        products = new T[10];
    }

    public TrainingNutritionMenu(int length)
    {
        products = new T[length];
    }

    public int Count => count;

    public int SetMaxCount
    {
        set
        {
            if (value > 0)
            {
                if (products.Length > 0)
                {
                    Array.Resize(ref products, value);
                }
                else
                {
                    products = new T[value];
                }
            }
        }
    }

    public bool IsEmpty
    {
        get { return count == 0; }
    }

    public void Push(T product)
    {
        if (count == products.Length)
        {
            Array.Resize(ref products, ++count);
            products[count - 1] = product;
        }
        else
        {
            products[count++] = product;
        }
    }

    public T? Pop()
    {
        if (IsEmpty)
        {
            Console.WriteLine("В меню пусто");
            return default;
        }
        T product = products[--count];

        return product;
    }

    public T? Peek()
    {
        if (IsEmpty)
        {
            Console.WriteLine("В меню пусто");
            return default;
        }
        T product = products[count - 1];

        return product;
    }
}
