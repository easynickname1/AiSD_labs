namespace lab02.task01;

class Item
{
    public string Name { get; set; }
    public int Value { get; set; }
    public int Weight { get; set; }

    public double ValuePerWeight => (double)Value / Weight;

    public Item(string name, int value, int weight)
    {
        Name = name;
        Value = value;
        Weight = weight;
    }
}
