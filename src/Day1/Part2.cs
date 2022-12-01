namespace Day1;

public static class Part2
{
    private static int[] _top3HighestCalories = { 0, 0, 0 };
    private static readonly List<int> CurrentElvesCalories = new List<int>(10);
    
    public static void Run()
    {
        string[] rows = File.ReadAllLines("input.txt");

        foreach (string row in rows)
        {
            if (row == string.Empty)
                SetIsTop3Elf();
            else
                CurrentElvesCalories.Add(Convert.ToInt32(row));
        }
        
        // Handles last elf if no end blank line provided
        if (CurrentElvesCalories.Any())
            SetIsTop3Elf();

        Console.WriteLine(_top3HighestCalories.Sum());
    }

    private static void SetIsTop3Elf()
    {
        var total = CurrentElvesCalories.Sum();

        for (int i = 0; i < 3; i++)
        {
            if (total <= _top3HighestCalories[i])
                continue;

            ShiftLeaderboardRight(i);
            _top3HighestCalories[i] = total;
            break;
        }
    
        CurrentElvesCalories.Clear();
    }

    private static void ShiftLeaderboardRight(int startIndex)
    {
        int[] newTop3 = new int[_top3HighestCalories.Length];
        Array.Copy(_top3HighestCalories, newTop3, newTop3.Length);

        for (int i = startIndex + 1; i < _top3HighestCalories.Length - startIndex; i++)
        {
            newTop3[i] = _top3HighestCalories[i - 1];
        }

        _top3HighestCalories = newTop3;
    }
}
