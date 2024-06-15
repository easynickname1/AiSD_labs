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
                    
                    break;
                case 3:

                    break;
            }
        }
        
    }
}