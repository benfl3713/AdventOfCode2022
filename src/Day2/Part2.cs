namespace Day2;

public static class Part2
{
    public static void Run()
    {
        string[] rows = File.ReadAllLines("input.txt");

        int score = rows.Sum(PlayRound);
        Console.WriteLine($"Players Score: {score}");
    }

    private static int PlayRound(string row)
    {
        Shape opponentsShape = GetShapeFromChar(row[0]);
        RoundResult expectedResult = GetResultFromChar(row[2]);

        Shape playersShape = GetPlayersShape(opponentsShape, expectedResult);

        return (int)expectedResult + (int)playersShape;
    }

    private static Shape GetPlayersShape(Shape opponentsShape, RoundResult expectedRoundResult)
    {
        if (expectedRoundResult == RoundResult.Draw)
            return opponentsShape;

        bool shouldWin = expectedRoundResult == RoundResult.Win;

        return opponentsShape switch
        {
            Shape.Rock => shouldWin ? Shape.Paper : Shape.Scissors,
            Shape.Paper => shouldWin ? Shape.Scissors : Shape.Rock,
            Shape.Scissors => shouldWin ? Shape.Rock : Shape.Paper,
            _ => throw new ArgumentOutOfRangeException(nameof(opponentsShape), opponentsShape, null)
        };
    }

    private static Shape GetShapeFromChar(char character)
    {
        return character switch
        {
            'A'=> Shape.Rock,
            'B' => Shape.Paper,
            'C' => Shape.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(character), character, null)
        };
    }
    
    private static RoundResult GetResultFromChar(char character)
    {
        return character switch
        {
            'X'=> RoundResult.Loss,
            'Y' => RoundResult.Draw,
            'Z' => RoundResult.Win,
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
