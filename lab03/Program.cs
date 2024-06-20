using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace lab03;

public class Program
{
    static void Main(string[] args)
    {
        int task = 1;

        while (task > 0)
        {
            Console.Write("\nНомер задания: ");
            task = Convert.ToInt32(Console.ReadLine());
            switch (task)
            {
                case 1:
                    BinaryHeap heap = new BinaryHeap();
                    heap.Actions();
                    break;
                case 2:
                    BFS bfs = new BFS(6);
                    bfs.AddEdge(0, 2);
                    bfs.AddEdge(0, 1);
                    bfs.AddEdge(0, 5);
                    bfs.AddEdge(1, 2);
                    bfs.AddEdge(1, 3);
                    bfs.AddEdge(2, 4);

                    Console.WriteLine("Обход в ширину (начиная с вершины 0):");
                    var watch = Stopwatch.StartNew();

                    bfs.BreadthFirstSearch(0);

                    watch.Stop();
                    Console.WriteLine($"\nВремя выполнения программы {watch.ElapsedMilliseconds}ms");
                    break;
                case 3:
                    Floyd floyd = new Floyd(4);
                    floyd.AddEdge(0, 1, 10);
                    floyd.AddEdge(0, 2, 5);
                    floyd.AddEdge(1, 2, 3);
                    floyd.AddEdge(1, 3, 1);
                    floyd.AddEdge(2, 3, 2);

                    // Вычисляем кратчайшие расстояния между всеми парами вершин
                    int[,] shortestDistances = floyd.FloydAlgorithm();

                    floyd.Print(shortestDistances);

                    break;
            }
        }
        
    }
}