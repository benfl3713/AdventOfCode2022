using System.Diagnostics;

namespace Common;

public static class PartRunner
{
    public static void RunWithTimer(Action part)
    {
        var timer = Stopwatch.StartNew();
        
        part.Invoke();
        
        timer.Stop();
        Console.WriteLine("Took: " + timer.Elapsed);
    }
}
