namespace Day2;

public static class Part1
{
    public static void Run()
    {
        string[] rows = File.ReadAllLines("input.txt");

        int score = rows.Sum(PlayRound);
        Console.WriteLine($"Players Score: {score}");
    }

    private static int PlayRound(string row)
    {
        Shape opponentsPlay = GetShapeFromChar(row[0]);
        Shape playersPlay = GetShapeFromChar(row[2]);

        RoundResult gameResult = GetResult(opponentsPlay, playersPlay);

        return (int)gameResult + (int)playersPlay;
    }

    private static RoundResult GetResult(Shape opponentsPlay, Shape playersPlay)
    {
        if (opponentsPlay == playersPlay)
            return RoundResult.Draw;

        return opponentsPlay switch
        {
            Shape.Scissors => playersPlay == Shape.Rock ? RoundResult.Win : RoundResult.Loss,
            _ => playersPlay - 1 == opponentsPlay ? RoundResult.Win : RoundResult.Loss
        };
    }

    private static Shape GetShapeFromChar(char character)
    {
        return character switch
        {
            'A' or 'X' => Shape.Rock,
            'B' or 'Y' => Shape.Paper,
            'C' or 'Z' => Shape.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(character), character, null)
        };
    }

    private enum RoundResult
    {
        Loss = 0,
        Draw = 3,
        Win = 6
    }

    private enum Shape
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }
}
