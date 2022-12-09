namespace Day8;

public static class Part1
{
    public static void Run()
    {
        string[] rows = File.ReadAllLines("input.txt");

        int[][] map = rows.Select(r => r.Select(c => Convert.ToInt32(char.GetNumericValue(c))).ToArray()).ToArray();

        int visibleCount = 0;

        for (int rowIndex = 1; rowIndex < map.Length - 1; rowIndex++)
        {
            int[] row = map[rowIndex];
            for (int columnIndex = 1; columnIndex < row.Length - 1; columnIndex++)
            {
                int current = row[columnIndex];

                if (IsVisibleToEdge(row, current, columnIndex - 1, 0, -1) || //Left 
                    IsVisibleToEdge(row, current, columnIndex + 1, row.Length, 1) || //Right
                    IsVisibleToEdge(map.Select(r => r[columnIndex]).ToArray(), current, rowIndex - 1, 0, -1) || //Top
                    IsVisibleToEdge(map.Select(r => r[columnIndex]).ToArray(), current, rowIndex + 1, map.Length, 1)) //Bottom
                    visibleCount++;
            }
        }

        int edgeCount = map[0].Length * 2 + (map.Length - 2) * 2;
        visibleCount += edgeCount;

        Console.WriteLine($"Total Visible Trees: {visibleCount}");
    }

    private static bool IsVisibleToEdge(int[] row, int current, int startIndex, int edgeIndex, int increment)
    {
        for (int i = startIndex; increment < 0 ? i >= edgeIndex : i < edgeIndex; i += increment)
        {
            int tree = row[i];
        
            if (tree >= current)
                return false;
        }

        return true;
    }
}
