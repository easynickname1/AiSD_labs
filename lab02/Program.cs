using lab02.task01;
using lab02.task02;
using lab02.task03;
using System.Diagnostics;

namespace lab02;

class Program
{
    static void Main(string[] args)
    {
        int item = 1;

        while (item > 0)
        {
            Console.Write("\nНомер задания: ");
            item = Convert.ToInt32(Console.ReadLine());
            switch (item)
            {
                case 1:
                    Knapsack.Run();
                    break;
                case 2:
                    int[] arr = { 10, 100, 5, 50, 20, 15 };
                    int[] test = { };
                    for (int i = 0; i < 1; i++)
                    {
                        test = test.Concat(arr).ToArray();
                    }

                    var watch = Stopwatch.StartNew();

                    Console.WriteLine(MatrixChainMultiplication.DynamicSolve(test));

                    watch.Stop();
                    Console.WriteLine($"Время выполнения программы {watch.ElapsedMilliseconds}ms");
                    break;
                case 3:
                    Algorithms.Run();
                    break;
            }
        }
    }
}