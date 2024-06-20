namespace lab03;

public class BFS
{
    private int[,] adjMatrix;
    private int numVert;

    public BFS(int numVert)
    {
        this.numVert = numVert;
        adjMatrix = new int[numVert, numVert];
    }

    public void AddEdge(int source, int destination)
    {
        adjMatrix[source, destination] = 1;
        adjMatrix[destination, source] = 1; // Для неориентированного графа
    }

    public void BreadthFirstSearch(int startVertex)
    {
        bool[] visited = new bool[numVert];
        Queue<int> queue = new Queue<int>();

        visited[startVertex] = true;
        queue.Enqueue(startVertex);

        while (queue.Count > 0)
        {
            int currentVertex = queue.Dequeue();
            Console.Write(currentVertex + " ");

            for (int i = 0; i < numVert; i++)
            {
                if (adjMatrix[currentVertex, i] == 1 && !visited[i])
                {
                    visited[i] = true;
                    queue.Enqueue(i);
                }
            }
        }
    }
}
