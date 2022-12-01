using System.Diagnostics;

namespace Day1;

public static class Part1
{
    private static int _highestCalories = 0;
    private static List<int> _currentElvesCalories = new List<int>(10);
    
    public static void Run()
    {
        var timer = Stopwatch.StartNew();

        string[] rows = File.ReadAllLines("input.txt");

        foreach (string row in rows)
        {
            if (row == string.Empty)
                SetIsHighestElf();
            else
                _currentElvesCalories.Add(Convert.ToInt32(row));
        }

        Console.WriteLine(_highestCalories);
        Console.WriteLine("Took: " + timer.Elapsed);
    }
    
    static void SetIsHighestElf()
    {
        var total = _currentElvesCalories.Sum();

        if (total > _highestCalories)
            _highestCalories = total;
    
        _currentElvesCalories = new List<int>(10);
    }
}
