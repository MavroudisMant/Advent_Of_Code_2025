using System.Drawing;

namespace AdventOfCode_2025;

public class Day9
{
    public void Task1()
    {
        var input = File.ReadAllLines("Inputs/day9.txt");

        var redTiles = input.Select(x =>
        {
            var nums = x.Split(',');
            return new Point(long.Parse(nums[1]), long.Parse(nums[0]));
        }).ToList();

        long maxArea = 0;
        long rowLength;
        long colLength;
        long area;
        for (int i = 0; i < redTiles.Count; i++)
        {
            for (int j = i+1; j < redTiles.Count; j++)
            {
                 rowLength = redTiles[i].Row - redTiles[j].Row + 1;
                 colLength = redTiles[i].Column - redTiles[j].Column + 1;
                 area = rowLength * colLength;
                 if (area > maxArea)
                 {
                     maxArea = area;
                 }
            }
        }
        
        Console.WriteLine(maxArea);
    }

    public void Task2()
    {
        var input = File.ReadAllLines("Inputs/day9.txt");

        var rowsDictionary = new Dictionary<long, List<long>>();
        var colsDictionary = new Dictionary<long, List<long>>();
        var redTiles = input.Select(x =>
        {
            var nums = x.Split(',');
            var point =  new Point(long.Parse(nums[1]), long.Parse(nums[0]));
            return point;
        }).ToList();
        
        var redGreenTiles = new List<Point>(redTiles);

        for (int i = 0; i < redTiles.Count; i++)
        {
            for (int j = i+1; j < redTiles.Count; j++)
            {
                if (redTiles[i].Row == redTiles[j].Row)
                {
                    var (startCol, finishCol) = redTiles[i].Column < redTiles[j].Column ? (redTiles[i].Column, redTiles[j].Column) : (redTiles[j].Column, redTiles[i].Column);
                    for (var k = startCol+1; k < finishCol; k++)
                    {
                        redGreenTiles.Add(new Point(redTiles[i].Row, k));
                    }
                }
                
                if (redTiles[i].Column == redTiles[j].Column)
                {
                    var (startRow, finishRow) = redTiles[i].Row < redTiles[j].Row ? (redTiles[i].Row, redTiles[j].Row) : (redTiles[j].Row, redTiles[i].Row);
                    for (var k = startRow+1; k < finishRow; k++)
                    {
                        redGreenTiles.Add(new Point(k, redTiles[i].Column));
                    }
                }
            }
        }

        PrintGrid(redGreenTiles.ToHashSet());
        // foreach (var tile in redGreenTiles)
        // {
        //     if (rowsDictionary.ContainsKey(tile.Row))
        //     {
        //         rowsDictionary[tile.Row].Add(tile.Column);
        //     }
        //     else
        //     {
        //         rowsDictionary.Add(tile.Row, [tile.Column]);
        //     }
        //     
        //     if (colsDictionary.ContainsKey(tile.Column))
        //     {
        //         colsDictionary[tile.Column].Add(tile.Row);
        //     }
        //     else
        //     {
        //         colsDictionary.Add(tile.Column, [tile.Row]);
        //     }
        // }
        //
        // long maxArea = 0;
        // long rowLength;
        // long colLength;
        // long area;
        // for (int i = 0; i < redTiles.Count; i++)
        // {
        //     for (int j = i+1; j < redTiles.Count; j++)
        //     {
        //         var corner1 = new Point(redTiles[i].Row, redTiles[j].Column);
        //         var corner2 = new Point(redTiles[j].Row, redTiles[i].Column);
        //
        //         if (!IsCornerValid(rowsDictionary, colsDictionary, corner1))
        //         {
        //             continue;
        //         }
        //
        //         if (!IsCornerValid(rowsDictionary, colsDictionary, corner2))
        //         {
        //             continue;
        //         }
        //         
        //         rowLength = redTiles[i].Row - redTiles[j].Row + 1;
        //         colLength = redTiles[i].Column - redTiles[j].Column + 1;
        //         area = rowLength * colLength;
        //         if (area > maxArea)
        //         {
        //             maxArea = area;
        //         }
        //     }
        // }
        //
        // Console.WriteLine(maxArea);
    }

    private static bool IsCornerValid(Dictionary<long, List<long>> rowsDictionary, Dictionary<long, List<long>> colsDictionary, Point corner)
    {
        if (!colsDictionary.ContainsKey(corner.Column) || !rowsDictionary.ContainsKey(corner.Row))
        {
            return false;
        }

        var maxRow = colsDictionary[corner.Column].Max();
        var minRow = colsDictionary[corner.Column].Min();

        if (minRow > corner.Row || maxRow < corner.Row)
        {
            return false;
        }
                
        var maxCol = rowsDictionary[corner.Row].Max();
        var minCol = rowsDictionary[corner.Row].Min();

        if (minCol > corner.Column || maxCol < corner.Column)
        {
            return false;
        }

        return true;
    }

    //Used for debug
    private static void PrintGrid(HashSet<Point> redGreenTiles)
    {
        var rows = redGreenTiles.Max(x => x.Row)+1;
        var cols = redGreenTiles.Max(x => x.Column)+1;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(redGreenTiles.Contains(new Point(i,j)) ? '#' : '.');
            }
            Console.WriteLine();
        }
    }

    private record Point(long Row, long Column);
}