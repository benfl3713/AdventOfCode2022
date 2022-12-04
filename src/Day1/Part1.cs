namespace Day1;

public static class Part1
{
    private static int _highestCalories;
    private static readonly List<int> CurrentElvesCalories = new List<int>(10);

    public static void Run()
    {
        string[] rows = File.ReadAllLines("input.txt");

        foreach (string row in rows)
        {
            if (row == string.Empty)
                SetIsHighestElf();
            else
                CurrentElvesCalories.Add(Convert.ToInt32(row));
        }
        
        // Handles last elf if no end blank line provided
        if (CurrentElvesCalories.Any())
            SetIsHighestElf();

        Console.WriteLine(_highestCalories);
    }

    private static void SetIsHighestElf()
    {
        int total = CurrentElvesCalories.Sum();

        if (total > _highestCalories)
            _highestCalories = total;
    
        CurrentElvesCalories.Clear();
    }
}
