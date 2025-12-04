namespace AdventOfCode_2025;

public class Day4
{
    public void Task1()
    {
        var input = File.ReadAllLines("Inputs/day4.txt");

        var total = 0;

        var floor = input.Select(x => x.ToArray()).ToArray();

        var rows = floor.Length;
        var columns = floor[0].Length;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                if (floor[row][col] == '.')
                {
                    continue;
                }

                //     -1,-1|-1, 0|-1,+1
                //      0,-1| 0, 0| 0,+1
                //     +1,-1|+1, 0|+1,+1

                var adjacent = 0;

                //Top left
                if (row > 0 && col > 0 && floor[row-1][col-1] == '@')
                {
                    adjacent++;
                }

                //Top middle
                if (row > 0 && floor[row-1][col] == '@')
                {
                    adjacent++;
                }

                //Top right
                if (row > 0 && col < columns-1  && floor[row-1][col+1] == '@')
                {
                    adjacent++;
                }

                //Middle left
                if (col > 0 && floor[row][col - 1] == '@')
                {
                    adjacent++;
                }

                //Middle right
                if (col < columns-1 && floor[row][col + 1] == '@')
                {
                    adjacent++;
                }

                //Bottom left
                if (row < rows-1 && col > 0 && floor[row+1][col-1] == '@')
                {
                    adjacent++;
                }

                //Bottom middle
                if (row < rows-1 && floor[row+1][col] == '@')
                {
                    adjacent++;
                }

                //Bottom left
                if (row < rows-1 && col < columns-1 && floor[row+1][col+1] == '@')
                {
                    adjacent++;
                }

                if (adjacent < 4)
                {
                    total++;
                }
            }
        }

        Console.WriteLine(total);
    }

    public void Task2()
    {
        var input = File.ReadAllLines("Inputs/day4.txt");

        var grandTotal = 0;
        var loopTotal = 0;

        var floor = input.Select(x => x.ToArray()).ToArray();

        var rows = floor.Length;
        var columns = floor[0].Length;

        do
        {
            loopTotal = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    if (floor[row][col] == '.')
                    {
                        continue;
                    }

                    //     -1,-1|-1, 0|-1,+1
                    //      0,-1| 0, 0| 0,+1
                    //     +1,-1|+1, 0|+1,+1

                    var adjacent = 0;

                    //Top left
                    if (row > 0 && col > 0 && floor[row-1][col-1] == '@')
                    {
                        adjacent++;
                    }

                    //Top middle
                    if (row > 0 && floor[row-1][col] == '@')
                    {
                        adjacent++;
                    }

                    //Top right
                    if (row > 0 && col < columns-1  && floor[row-1][col+1] == '@')
                    {
                        adjacent++;
                    }

                    //Middle left
                    if (col > 0 && floor[row][col - 1] == '@')
                    {
                        adjacent++;
                    }

                    //Middle right
                    if (col < columns-1 && floor[row][col + 1] == '@')
                    {
                        adjacent++;
                    }

                    //Bottom left
                    if (row < rows-1 && col > 0 && floor[row+1][col-1] == '@')
                    {
                        adjacent++;
                    }

                    //Bottom middle
                    if (row < rows-1 && floor[row+1][col] == '@')
                    {
                        adjacent++;
                    }

                    //Bottom left
                    if (row < rows-1 && col < columns-1 && floor[row+1][col+1] == '@')
                    {
                        adjacent++;
                    }

                    if (adjacent < 4)
                    {
                        grandTotal++;
                        loopTotal++;
                        floor[row][col] = '.';
                    }
                }
            }
        }
        while (loopTotal > 0);

        Console.WriteLine(grandTotal);
    }
}