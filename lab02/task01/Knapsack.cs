namespace lab02.task01;

class Knapsack
{
    public static void Run()
    {
        List<Item> items = new List<Item>()
        {
            new Item("Ноутбук", 15, 3),
            new Item("Кроссовки", 10, 2),
            new Item("Футболка", 7, 3),
            new Item("Книга", 12, 5),
        };

        int capacity = 10;

        List<Item> selectedItems = Knapsack.Solve(items, capacity);

        Console.WriteLine("Выбранные предметы:");
        foreach (var item in selectedItems)
        {
            Console.WriteLine($"{item.Name}: {item.Value}руб. - {item.Weight}кг.");
        }

        Console.WriteLine($"Общая ценность: {selectedItems.Sum(item => item.Value)}руб.");
    }

    public static List<Item> Solve(List<Item> items, int capacity)
    {
        items.Sort((a, b) => b.ValuePerWeight.CompareTo(a.ValuePerWeight));

        List<Item> selectedItems = new List<Item>();
        int weight = 0;
        int value = 0;

        foreach (var item in items)
        {
            if (item.Weight <= capacity - weight)
            {
                selectedItems.Add(item);
                weight += item.Weight;
                value += item.Value;
            }
            else
            {
                int fraction = (capacity - weight) / item.Weight;
                selectedItems.Add(new Item(
                    item.Name,
                    item.Value * fraction,
                    item.Weight * fraction
                ));
                value += item.Value * fraction;
                break;
            }
        }

        return selectedItems;
    }
}
