namespace Day5;

public static class Part1
{
    public static void Run()
    {
        string[] rows = File.ReadAllLines("input.txt");
        int splitIndex = rows.ToList().IndexOf(string.Empty);

        string[] strCrates = rows.Take(splitIndex).ToArray();
        string[] steps = rows.Skip(splitIndex + 1).ToArray();

        Stack<char>[] crates = ParseCrates(strCrates);
        
        foreach (string step in steps)
        {
            string[] parts = step.Split(' ');
            
            int amountToMove = Convert.ToInt32(parts[1]);
            int fromCrate = Convert.ToInt32(parts[3]);
            int toCrate = Convert.ToInt32(parts[5]);

            for (int i = 0; i < amountToMove; i++)
            {
                char crate = crates[fromCrate - 1].Pop();
                crates[toCrate - 1].Push(crate);
            }
        }

        foreach (Stack<char> stack in crates)
        {
            Console.Write(stack.Peek());
        }

        Console.WriteLine(Environment.NewLine);
    }

    private static Stack<char>[] ParseCrates(string[] crates)
    {
        int SaveDivideBy4(int i)
        {
            if (i == 0)
                return 0;
            
            return i / 4;
        }

        Stack<char>?[] stacks = new Stack<char>[SaveDivideBy4(crates.Last().Length + 1)];

        foreach (string crate in crates.Reverse())
        {
            if (crate == crates.Last() || string.IsNullOrEmpty(crate))
                continue;

            for (int i = 0; i < crate.Length; i += 4)
            {
                char crateLetter = crate[i + 1];
                if (crateLetter == ' ')
                    continue;
                
                stacks[SaveDivideBy4(i)] ??= new Stack<char>();
                stacks[SaveDivideBy4(i)]?.Push(crateLetter);
            }
        }

        return stacks!;
    }
}
