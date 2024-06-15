namespace lab02.task03;

public class Algorithms
{
    static readonly int inf = 99999;

    public static void Run()
    {
        Console.WriteLine("1. Алгоритм Флойда — Уоршелла\n2. Перебор всех подмножеств множества\n3. Устойчивый алгоритм сортировки подсчётом");
        int select = Convert.ToInt32(Console.ReadLine());
        switch (select)
        {
            case 1:
                int[,] graph = {
                    { 0, 5, inf, 10 },
                    { inf, 0, 3, inf },
                    { inf, inf, 0, 1 },
                    { inf, inf, inf, 0 }
                };
                FloydWarshall(graph);
                break;
            case 2:
                List<int> set = new List<int>() { 1, 2, 3 };

                // Получение всех подмножеств
                List<List<int>> powerSet = GetAllSubsets(set);

                // Вывод всех подмножеств
                Console.WriteLine("Все подмножества:");
                foreach (List<int> subset in powerSet)
                {
                    Console.Write("[ ");
                    foreach (int num in subset)
                    {
                        Console.Write(num + " ");
                    }
                    Console.WriteLine("]");
                }
                break;
            case 3:
                int[] arr = { 5, 2, 9, 5, 2, 3, 5 };
                CountingSort(arr);
                break;
        }
    }

    /// <summary>
    /// Алгоритм Флойда — Уоршелла,
    /// Сложность - Θ(n^3)
    /// </summary>
    /// <param name="graph"></param>
    public static void FloydWarshall(int[,] graph)
    {
        int n = graph.GetLength(0);
        int[,] path = (int[,])graph.Clone();


        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (path[i, k] + path[k, j] < path[i, j])
                        path[i, j] = path[i, k] + path[k, j];
                }
            }
        }

        Console.WriteLine("Матрица кратчайшего пути:");
        for (int i = 0; i < path.GetLength(0); ++i)
        {
            for (int j = 0; j < path.GetLength(1); ++j)
            {
                if (path[i, j] == inf)
                    Console.Write("inf".PadRight(7));
                else
                    Console.Write(path[i, j].ToString().PadRight(7));
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Перебор всех подмножеств множества,
    /// Сложность - Θ(2^n)
    /// </summary>
    /// <param name="set"></param>
    /// <returns></returns>
    public static List<List<int>> GetAllSubsets(List<int> set)
    {
        List<List<int>> powerSet = new();
        powerSet.Add(new List<int>()); // Добавляем пустое множество

        for (int i = 0; i < set.Count; i++)
        {
            int currentSubsetsCount = powerSet.Count;
            for (int j = 0; j < currentSubsetsCount; j++)
            {
                List<int> newSubset = new(powerSet[j]);
                newSubset.Add(set[i]);
                powerSet.Add(newSubset);
            }
        }
        return powerSet;
    }

    /// <summary>
    /// Устойчивый алгоритм сортировки подсчётом,
    /// Сложность - Θ(n+k)
    /// </summary>
    /// <param name="array"></param>
    public static void CountingSort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
        
        // Найдем минимальное и максимальное значения в массиве
        int minVal = array.Min();
        int maxVal = array.Max();

        // Создадим массив подсчета
        int[] counts = new int[maxVal - minVal + 1];

        // Подсчитаем количество вхождений каждого элемента
        foreach (int num in array)
        {
            counts[num - minVal]++;
        }

        // Сформируем отсортированный массив
        int sortedIndex = 0;
        for (int i = 0; i < counts.Length; i++)
        {
            for (int j = 0; j < counts[i]; j++)
            {
                Console.Write((array[sortedIndex++] = i + minVal) + " ");
            }
        }
    }
}
