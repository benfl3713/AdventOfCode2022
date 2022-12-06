namespace Day4;

public static class Part1
{
    public static void Run()
    {
        int count = 0;
        string[] rows = File.ReadAllLines("input.txt");

        foreach (string row in rows)
        {
            string[] elves = row.Split(',');
            var elf1 = GetElfSection(elves[0]);
            var elf2 = GetElfSection(elves[1]);

            if (elf2.from >= elf1.from && elf2.to <= elf1.to)
                count++;
            else if (elf1.from >= elf2.from && elf1.to <= elf2.to)
                count++;
        }

        Console.WriteLine($"Pairs: {count}");
    }

    private static (int from, int to) GetElfSection(string elf)
    {
        string[] parts = elf.Split('-');
        return (Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]));
    }
}
