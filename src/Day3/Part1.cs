namespace Day3;

public static class Part1
{
    public static void Run()
    {
        string[] rows = File.ReadAllLines("input.txt");
        var sum = rows.Sum(GetItemNumber);

        Console.WriteLine($"Item Sum: {sum}");
    }

    private static int GetItemNumber(string row)
    {
        var rucksack = SplitRuckSackByCompartment(row);
        var errorItem = rucksack.first.First(i => rucksack.second.Any(s => s == i));
        return GetPriority(errorItem);
    }

    private static (string first, string second) SplitRuckSackByCompartment(string rucksack)
    {
        if (rucksack.Length % 2 != 0)
            throw new Exception("Cannot split rucksack: " + rucksack);

        string firstCompartment = rucksack.Substring(0, rucksack.Length / 2);
        string secondCompartment = rucksack.Substring(rucksack.Length / 2);

        return (firstCompartment, secondCompartment);
    }

    private static int GetPriority(char item)
    {
        if (char.IsUpper(item))
            return item - 38;

        return item - 96;
    }
}
