using System.Diagnostics;

namespace Day1;

public static class Part2
{
    private static int[] Top3HighestCalories = { 0, 0, 0 };
    private static List<int> _currentElvesCalories = new List<int>(10);
    
    public static void Run()
    {
        var timer = Stopwatch.StartNew();

        string[] rows = File.ReadAllLines("input.txt");

        foreach (string row in rows)
        {
            if (row == string.Empty)
                SetIsTop3Elf();
            else
                _currentElvesCalories.Add(Convert.ToInt32(row));
        }
        
        if (_currentElvesCalories.Any())
            SetIsTop3Elf();

        Console.WriteLine(Top3HighestCalories.Sum());
        Console.WriteLine("Took: " + timer.Elapsed);
    }
    
    static void SetIsTop3Elf()
    {
        var total = _currentElvesCalories.Sum();

        for (int i = 0; i < 3; i++)
        {
            if (total <= Top3HighestCalories[i])
                continue;

            ShiftLeaderboardRight(i);
            Top3HighestCalories[i] = total;
            break;
        }
    
        _currentElvesCalories = new List<int>(10);
    }

    private static void ShiftLeaderboardRight(int startIndex)
    {
        int[] newTop3 = new int[Top3HighestCalories.Length];
        Array.Copy(Top3HighestCalories, newTop3, newTop3.Length);

        for (int i = startIndex + 1; i < Top3HighestCalories.Length - startIndex; i++)
        {
            newTop3[i] = Top3HighestCalories[i - 1];
        }

        Top3HighestCalories = newTop3;
    }
}
