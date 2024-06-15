namespace lab03;

public class BinaryHeap
{
    private List<int> list;

    public int HeapSize => list.Count;

    public void Actions()
    {
        int[] arr = new int[10];
        for (int i = 0; i < arr.Length; i++)
        {
            Random r = new Random();
            arr[i] = r.Next(20);
            Console.Write(arr[i] + " ");
        }
        Build(arr);

        int action = 1;

        while (action > 0)
        {
            Console.Write("\n1. Добавить элемент\n2. Удалить максимальный\n3. Удалить по значению\n4. Упорядочить\n5. Вывести\n0. Выйти\n");
            action = Convert.ToInt32(Console.ReadLine());
            switch (action)
            {
                case 1:
                    Add(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 2:
                    Console.WriteLine("Максимальный: " + DeleteMax());
                    break;
                case 3:
                    list.Remove(Convert.ToInt32(Console.ReadLine()));
                    break;
                case 4:
                    Heapify(0);
                    break;
                case 5:
                    Print();
                    break;
                case 0:
                    return;
            }
        }
    }

    public void Build(int[] array)
    {
        list = array.ToList();
        for (int i = HeapSize / 2; i >= 0; i--)
        {
            Heapify(i);
        }
    }

    public void Add(int value)
    {
        list.Add(value);
        int i = HeapSize - 1;
        int parent = (i - 1) / 2;

        while (i > 0 && list[parent] < list[i])
        {
            int tmp = list[i];
            list[i] = list[parent];
            list[parent] = tmp;

            i = parent;
            parent = (i - 1) / 2;
        }
    }

    public int DeleteMax()
    {
        int max = list[0];
        list[0] = list[HeapSize - 1];
        list.RemoveAt(HeapSize - 1);
        return max;
    }

    public void Heapify(int i) 
    {
        int leftChild;
        int rightChild;
        int largestChild;

        for (; ; )
        {
            leftChild = 2 * i + 1;
            rightChild = 2 * i + 2;
            largestChild = i;

            if (leftChild < HeapSize && list[leftChild] > list[largestChild])
            {
                largestChild = leftChild;
            }

            if (rightChild < HeapSize && list[rightChild] > list[largestChild])
            {
                largestChild = rightChild;
            }

            if (largestChild == i)
            {
                 break;
            }

            int tmp = list[i];
            list[i] = list[largestChild];
            list[largestChild] = tmp;
            i = largestChild;
        }
    }

    public void HeapSort(int[] array)
    {
        Build(array);
        for (int i = array.Length - 1; i >= 0; i--)
        {
            array[i] = DeleteMax();
            Heapify(i);
        }
    }

    public void Print()
    {
        int gaps = 32;
        int rowItems = 1;
        int colNumber = 0;

        for (int i = 0; i < HeapSize; i++)
        {
            if (colNumber == 0) // проверяем первый ли элемент в текущей строке
            {
                for (int k = 0; k < gaps; k++)
                {
                    Console.Write(" ");
                }
            }
            Console.Write(list[i]); // вершина

            if (++colNumber == rowItems) // проверяем последний ли элемент в строке
            {
                gaps /= 2;
                rowItems *= 2;
                colNumber = 0;
                Console.WriteLine();
            }

            else
            {
                for (int k = 0; k < gaps * 2 - 2; k++)
                {
                    Console.Write(" ");
                }
            }
        }

        Console.WriteLine();
    }
}
