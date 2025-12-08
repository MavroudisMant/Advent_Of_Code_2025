namespace AdventOfCode_2025;

public class Day7
{
    public void Task1()
    {
        var input = File.ReadAllLines("Inputs/day7.txt");

        var total = 0;

        var grid = new List<List<char>>();

        foreach (var line in input)
        {
            grid.Add(line.ToList());
        }

        var rows = grid.Count;
        var cols = grid[0].Count;

        var (startRow, startCol) = GetStartingPosition(grid);

        for (var i = 0; i < rows-1; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (grid[i][j] == '|')
                {
                    if (grid[i + 1][j] == '^')
                    {
                        grid[i + 1][j-1] = '|';
                        grid[i + 1][j+1] = '|';
                        total++;
                    }
                    else
                    {
                        grid[i + 1][j] = '|';
                    }
                }
            }
        }

        Console.WriteLine(total);
    }

    public void Task2()
    {
        var input = File.ReadAllLines("Inputs/day7.txt");

        var total = 0;

        var grid = new List<List<char>>();

        foreach (var line in input)
        {
            grid.Add(line.ToList());
        }

        var rows = grid.Count;
        var cols = grid[0].Count;

        var cache = new Dictionary<(int row, int col), int>();

        var (startRow, startCol) = GetStartingPosition(grid);

        total = GetTimelines(grid, startRow, startCol, rows-1, cache);

        Console.WriteLine(total);
    }

    private int GetTimelines(List<List<char>> grid, int row, int col, int maxRows, Dictionary<(int row, int col), int> cache)
    {
        if (cache.ContainsKey((row, col)))
        {
            return cache[(row, col)];
        }
        if (row == maxRows)
        {
            return 1;
        }

        if (grid[row][col] == '.')
        {
            return GetTimelines(grid, row+1, col, maxRows, cache);
        }

        var total = GetTimelines(grid, row+1, col-1, maxRows, cache) + GetTimelines(grid, row, col+1, maxRows, cache);
        cache.TryAdd((row, col), total);
        return total;
    }

    private (int row, int col) GetStartingPosition(List<List<char>> grid)
    {
        for (int i = 0; i < grid.Count; i++)
        {
            for (int j = 0; j < grid[0].Count; j++)
            {
                if (grid[i][j] == 'S')
                {
                    grid[i][j] = '|';
                    return (i, j);
                }
            }
        }

        return (0, 0);
    }
}