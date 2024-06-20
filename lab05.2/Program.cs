using lab05._2;
using System.Diagnostics;

namespace lab05;

public class Program
{
    static void Main(string[] args)
    {
        TrainingNutritionMenuLinkedList<string> menu = new TrainingNutritionMenuLinkedList<string>();
        //TrainingNutritionMenuArray<string> menu = new TrainingNutritionMenuArray<string>();

        string path = AppContext.BaseDirectory + "..\\..\\..\\src\\Dictionary20000.txt";
        string[] fileText = File.ReadAllLines(path);


        var watch = Stopwatch.StartNew();
        for (int i = 0; i < fileText.Length; i++)
        {
            menu.Push(fileText[i]);
        }
        watch.Stop();
        Console.WriteLine($"\nВремя выполнения программы {watch.ElapsedMilliseconds}ms");

        watch.Restart();
        for (int i = 0; i < 16384; i++)
        {
            menu.Pop();
        }
        watch.Stop();
        Console.WriteLine($"\nВремя выполнения программы {watch.ElapsedTicks}ticks");

        string head = new string(menu.Peek());
        Console.WriteLine(menu.Count);
        Console.WriteLine(head);
    }
}