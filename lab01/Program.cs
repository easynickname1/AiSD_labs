namespace lab01;

public class Program
{
    static void WriteArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"{arr[i]} ");
        }
        Console.WriteLine();
    }

    static int[] BubbleSort(int[] arr)
    {
        int tmp;
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    tmp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = tmp;
                }
            }
        }
        return arr;
    }

    static int[] Merge(int[] buffA, int[] buffB)
    {
        int[] buffC = new int[buffA.Length + buffB.Length];
        int indexA = 0, indexB = 0;

        for (int i = 0; i < buffC.Length; i++)
        {
            if (indexA < buffA.Length && indexB < buffB.Length)
            {
                if (buffA[indexA] < buffB[indexB])
                {
                    buffC[i] = buffA[indexA];
                    indexA++;
                }
                else
                {
                    buffC[i] = buffB[indexB];
                    indexB++;
                }
            }
            else if (indexA == buffA.Length && indexB < buffB.Length)
            {
                buffC[i] = buffB[indexB];
                indexB++;
            }
            else if (indexA < buffA.Length && indexB == buffB.Length)
            {
                buffC[i] = buffA[indexA];
                indexA++;
            }
            else
            {
                buffC[i] = 0;
            }
        }
        return buffC;
    }

    static int half = 0;

    static int[] MergeSort(int[] array)
    {
        if (array == null)
            return null;
        if (array.Length < 2)
            return array;

        half = array.Length / 2;
        int[] buffA = new int[half];
        for (int i = 0; i < half; i++)
        {
            buffA[i] = array[i];
        }

        int[] buffB = new int[array.Length - half];
        for (int i = half; i < array.Length; i++)
        {
            buffB[i - half] = array[i];
        }

        buffA = MergeSort(buffA);
        buffB = MergeSort(buffB);


        return Merge(buffA, buffB);
    }

    static void SelectSort(int option)
    {
        int[] arr = new int[20000];

        for (int i = 0; i < arr.Length; i++)
        {
            Random rnd = new Random();
            arr[i] = rnd.Next() % 50;
        }

        WriteArray(arr);
        if (option == 2)
            arr = BubbleSort(arr);
        if (option == 3)
            arr = MergeSort(arr);
        WriteArray(arr);
    }

    static void Stack()
    {
        TrainingNutritionMenu<string> menu = new TrainingNutritionMenu<string>();

        string path = "C:\\Users\\user\\Projects\\source\\repos\\AiSD_labs\\lab01\\src\\Dictionary20000.txt";
        string[] fileText = File.ReadAllLines(path);

        for (int i = 0; i < fileText.Length; i++)
        {
            menu.Push(fileText[i]);
        }

        for (int i = 0;i < 5; i++)
        {
            menu.Pop();
        }
        
        string head = new string(menu.Peek());
        Console.WriteLine(menu.Count);
        Console.WriteLine(head);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Выберите задание:");
        int opt = Convert.ToInt32(Console.ReadLine());
        if (opt == 1)
            Stack();
        if (opt == 2 || opt == 3)
            SelectSort(opt);
    }
}