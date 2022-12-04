namespace Day3;

public static class Part2
{
    public static void Run()
    {
        string[] rows = File.ReadAllLines("input.txt");

        if (rows.Length % 3 != 0)
            throw new Exception("Invalid Row Count");

        int totalPrioritySum = 0;

        for (int i = 0; i < rows.Length; i += 3)
        {
            string first = rows[i];
            string second = rows[i + 1];
            string third = rows[i + 2];

            var badgeItem = first.First(item => second.Contains(item) && third.Contains(item));
            
            totalPrioritySum += GetPriority(badgeItem);
        }

        Console.WriteLine($"Badge Total Priority: {totalPrioritySum}");
    }

    private static int GetPriority(char item)
    {
        if (char.IsUpper(item))
            return item - 38;

        return item - 96;
    }
}
