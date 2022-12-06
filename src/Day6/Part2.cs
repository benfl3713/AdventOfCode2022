namespace Day6;

public static class Part2
{
    public static void Run()
    {
        string buffer = File.ReadAllText("input.txt");

        for (var i = 13; i < buffer.Length; i++)
        {
            var previousThreeChars = buffer[(i-13)..i];
            var fourChars = previousThreeChars + buffer[i];

            if (fourChars.Distinct().Count() == 14)
            {
                Console.WriteLine(i + 1);
                break;
            }
        }
    }
}
