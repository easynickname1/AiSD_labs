using lab02.task01;
using lab02.task02;

namespace lab02.task03;

public class Algorithms
{
    public void Run()
    {
        int select = Convert.ToInt32(Console.ReadLine());
        switch (select)
        {
            case 1:
                FloydWarshall(Convert.ToInt32(Console.ReadLine()));
                break;
            case 2:
                List<int> numbers = new() { 1, 2, 3 };
                GetAllSubsets(numbers);
                break;
            case 3:
                break;
        }
    }

    /// <summary>
    /// Алгоритм Флойда — Уоршелла,
    /// Сложность - Θ(n^3)
    /// </summary>
    /// <param name="n"></param>
    public static void FloydWarshall(int n)
    {
        int[,,] A = new int[n + 1, n, n];
        int[,] W = new int[n, n];

        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                A[0, i, j] = W[i, j];
            }
        }

        for (int k = 1; k <= n; ++k)
        {
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    A[k, i, j] = Math.Min(A[k - 1, i, j], A[k - 1, i, k - 1] + A[k - 1, k - 1, j]);
                }
            }
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
    public static void Sort(int[] array)
    {
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
                array[sortedIndex++] = i + minVal;
            }
        }
    }
}
