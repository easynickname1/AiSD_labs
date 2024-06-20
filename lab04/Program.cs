using System;
using System.Diagnostics;
using static System.Collections.Specialized.BitVector32;

namespace lab04;

public class Program
{
    static void Main(string[] args)
    {
        int item = -1;

        while (item != 0)
        {
            Console.WriteLine("1. Линейное пробирование");
            Console.WriteLine("2. Метод цепочек");

            try { item = int.Parse(Console.ReadLine()); }
            catch { Console.WriteLine("Неверный ввод значения. Введите число."); }

            switch (item)
            {
                case 1:
                    if (RunLinearProbingHashTable() == true)
                        continue;
                    break;
                case 2:
                    if (RunChainedHashTable() == true)
                        continue;
                    break;
                case 0:
                    return;
            }
        }
    }

    static bool RunLinearProbingHashTable()
    {
        LinearProbingHashTable<string, int> hashTable = new LinearProbingHashTable<string, int>();

        hashTable.Add("orange", 1);
        hashTable.Add("apple", 2);
        hashTable.Add("mandarin", 3);

        Console.WriteLine("Размер: " + hashTable.Size);
        Console.WriteLine("Содержит ключ 'Апельсин': " + hashTable.ContainsKey("Апельсин"));
        Console.WriteLine("Значение по ключу 'Яблоко': " + hashTable.Get("Яблоко"));

        int choice = -1;
        while (choice != 0)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Добавить элемент");
            Console.WriteLine("2. Проверить наличие ключа");
            Console.WriteLine("3. Получить значение по ключу");
            Console.WriteLine("4. Вывести размер таблицы");
            Console.WriteLine("5. Вывести хэш-таблицу");
            Console.WriteLine("0. Выход");

            try { choice = int.Parse(Console.ReadLine()); }
            catch { Console.WriteLine("Неверный ввод значения. Введите число."); }

            switch (choice)
            {
                case 1:
                    Console.Write("Введите ключ: ");
                    string key = Console.ReadLine();
                    Console.Write("Введите значение: ");
                    if (!int.TryParse(Console.ReadLine(), out int value))
                    {
                        Console.WriteLine("Неверный ввод значения. Введите число.");
                        break;
                    }

                    Console.WriteLine("Коэффициэнт заполнения: {0}", hashTable.GetLoadFactor());

                    try { Console.WriteLine(hashTable.Add(key, value)); }
                    catch { }
                    
                    Console.WriteLine("Элемент добавлен.");
                    break;
                case 2:
                    Console.Write("Введите ключ: ");
                    Console.WriteLine("Ключ найден: " + hashTable.ContainsKey(Console.ReadLine()));
                    break;
                case 3:
                    Console.Write("Введите ключ: ");
                    string keyToGet = Console.ReadLine();
                    Console.WriteLine("Значение: " + hashTable.Get(keyToGet));
                    break;
                case 4:
                    Console.WriteLine("Размер таблицы: " + hashTable.Size);
                    break;
                case 5:
                    hashTable.PrintHashTable();
                    break;
                case 0:
                    return false;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
        return true;
    }

    static bool RunChainedHashTable()
    {
        ChainedHashTable<string, int> hashTable = new ChainedHashTable<string, int>();

        hashTable.Add("apple", 1);
        hashTable.Add("mandarin", 2);
        hashTable.Add("orange", 3);

        int choice = -1;
        while (choice != 0)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Добавить элемент");
            Console.WriteLine("2. Проверить наличие ключа");
            Console.WriteLine("3. Получить значение по ключу");
            Console.WriteLine("4. Вывести размер таблицы");
            Console.WriteLine("5. Вывести хэш-таблицу");
            Console.WriteLine("0. Выход");

            try { choice = int.Parse(Console.ReadLine()); }
            catch { Console.WriteLine("Неверный ввод значения. Введите число."); }

            switch (choice)
            {
                case 1:
                    Console.Write("Введите ключ: ");
                    string key = Console.ReadLine();
                    Console.Write("Введите значение: ");
                    if (!int.TryParse(Console.ReadLine(), out int value))
                    {
                        Console.WriteLine("Неверный ввод значения. Введите число.");
                        break;
                    }
                    try
                    {
                        hashTable.Add(key, value);
                        Console.WriteLine("Элемент добавлен.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case 2:
                    Console.Write("Введите ключ: ");
                    Console.WriteLine("Ключ найден: " + hashTable.ContainsKey(Console.ReadLine()));
                    break;
                case 3:
                    Console.Write("Введите ключ: ");
                    string keyToGet = Console.ReadLine();
                    try
                    {
                        Console.WriteLine("Значение: " + hashTable.Get(keyToGet));
                    }
                    catch (KeyNotFoundException)
                    {
                        Console.WriteLine($"Ключ '{keyToGet}' не найден.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Размер таблицы: " + hashTable.Size);
                    break;
                case 5:
                    hashTable.PrintHashTable();
                    break;
                case 0:
                    return false;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
        return true;
    }
}