namespace lab03;

public class Floyd
{
    private List<List<Tuple<int, int>>> adjacencyList;
    private int numVertices;

    public Floyd(int numVertices)
    {
        this.numVertices = numVertices;
        adjacencyList = new List<List<Tuple<int, int>>>(numVertices);
        for (int i = 0; i < numVertices; i++)
        {
            adjacencyList.Add(new List<Tuple<int, int>>());
        }
    }

    public void AddEdge(int source, int destination, int weight)
    {
        adjacencyList[source].Add(new Tuple<int, int>(destination, weight));
    }

    public int[,] FloydAlgorithm()
    {
        int[,] distances = new int[numVertices, numVertices];

        // Инициализация матрицы
        for (int i = 0; i < numVertices; i++)
        {
            for (int j = 0; j < numVertices; j++)
            {
                if (i == j)
                {
                    distances[i, j] = 0;
                }
                else
                {
                    distances[i, j] = int.MaxValue;
                }
            }
        }

        // Заполнение матрицы
        for (int i = 0; i < numVertices; i++)
        {
            foreach (var edge in adjacencyList[i])
            {
                distances[i, edge.Item1] = edge.Item2;
            }
        }

        // Алгоритм Флойда
        for (int k = 0; k < numVertices; k++)
        {
            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    if (distances[i, k] != int.MaxValue && distances[k, j] != int.MaxValue &&
                        distances[i, k] + distances[k, j] < distances[i, j])
                    {
                        distances[i, j] = distances[i, k] + distances[k, j];
                    }
                }
            }
        }

        return distances;
    }

    public void Print(int[,] distances)
    {
        Console.WriteLine("Список смежности:");
        for (int i = 0; i < numVertices; i++)
        {
            Console.Write("[" + i + "] -> ");
            for (int j = 0; j < numVertices; j++)
            {
                if (distances[i, j] != int.MaxValue && distances[i, j] != 0)
                {
                    Console.Write("[" + j + "](" + distances[i, j] + "), ");
                }
            }
            Console.WriteLine();
        }
    }
}
