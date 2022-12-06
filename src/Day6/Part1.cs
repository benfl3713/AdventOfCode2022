namespace Day6;

public static class Part1
{
    public static void Run()
    {
        string buffer = File.ReadAllText("input.txt");

        for (var i = 3; i < buffer.Length; i++)
        {
            var previousThreeChars = buffer[(i-3)..i];
            var fourChars = previousThreeChars + buffer[i];

            if (fourChars.Distinct().Count() != 4)
                continue;
            
            Console.WriteLine(i + 1);
            break;
        }
    }
}
