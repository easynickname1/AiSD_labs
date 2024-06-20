using System.Diagnostics;

namespace lab05;

public class Program
{
    static void Main(string[] args)
    {
        int[] tableSizes = { 262144, 524288, 1048576, 2097152, 4194304 };
        double[] loadFactors = { 0, 0.1, 0.25, 0.5, 0.7, 0.9, 0.95, 0.99 };

        foreach (int tableSize in tableSizes)
        {
            Console.WriteLine($"\nРазмер хэш-таблицы: {tableSize}");

            foreach (double loadFactor in loadFactors)
            {
                var watch = Stopwatch.StartNew();

                MyHashSet<int, int> hashTable = new MyHashSet<int, int>(tableSize);

                int numElements = (int)(tableSize * loadFactor);

                Random random = new Random();
                for (int i = 0; i < numElements; i++)
                {
                    hashTable.Add(random.Next(tableSize * 10), i);
                };
                hashTable.Add(random.Next(tableSize * 10), numElements);

                try { hashTable.Get(random.Next(numElements)); }
                catch (KeyNotFoundException) { }

                try
                {
                    hashTable.Get(tableSize * 10 + 1);
                }
                catch (KeyNotFoundException) { }

                watch.Stop();
                Console.WriteLine($"Коэффициент заполнения {loadFactor}, Время выполнения программы {watch.ElapsedMilliseconds}ms");
            }
        }
    }
}