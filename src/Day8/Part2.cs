namespace Day8;

public static class Part2
{
    public static void Run()
    {
        string[] rows = File.ReadAllLines("input.txt");

        int[][] map = rows.Select(r => r.Select(c => Convert.ToInt32(char.GetNumericValue(c))).ToArray()).ToArray();

        int highestScore = 0;

        for (int rowIndex = 1; rowIndex < map.Length - 1; rowIndex++)
        {
            int[] row = map[rowIndex];
            for (int columnIndex = 1; columnIndex < row.Length - 1; columnIndex++)
            {
                int current = row[columnIndex];
                int? left = NextTallerTreeToEdge(row, current, columnIndex - 1, 0, -1);
                int? right = NextTallerTreeToEdge(row, current, columnIndex + 1, row.Length, 1);
                int? top = NextTallerTreeToEdge(map.Select(r => r[columnIndex]).ToArray(), current, rowIndex - 1, 0, -1);
                int? bottom = NextTallerTreeToEdge(map.Select(r => r[columnIndex]).ToArray(), current, rowIndex + 1, map.Length, 1);

                int score = (left ?? 1) * (right ?? 1) * (top ?? 1) * (bottom ?? 1);

                if (score > highestScore)
                    highestScore = score;
            }
        }

        Console.WriteLine($"Highest Score: {highestScore}");
    }

    private static int? NextTallerTreeToEdge(int[] row, int current, int startIndex, int edgeIndex, int increment)
    {
        int distanceAway = 0;
        for (int i = startIndex; increment < 0 ? i >= edgeIndex : i < edgeIndex; i += increment)
        {
            int tree = row[i];
        
            if (tree >= current)
                return ++distanceAway;

            distanceAway++;
        }

        return distanceAway == 0 ? null : distanceAway;
    }
}
