namespace AdventOfCode_2025;

public class Day5
{
    public void Task1()
    {
        var input = File.ReadAllLines("Inputs/day5.txt");

        var total = 0;
        var freshProducts = new List<(long, long)>();

        foreach (var line in input)
        {
            if (line.Contains('-'))
            {
                var nums  = line.Split('-');
                var num1 = long.Parse(nums[0]);
                var num2 = long.Parse(nums[1]);
                freshProducts.Add((num1, num2));

                continue;
            }

            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            var product = long.Parse(line);

            if (freshProducts.Any(x => x.Item1 <= product && product <= x.Item2))
            {
                total++;
            }
        }

        Console.WriteLine(total);
    }

    public void Task2()
    {
        var input = File.ReadAllLines("Inputs/day5.txt");

        var total = 0L;
        var freshProducts = new List<ProductRange>();

        foreach (var line in input)
        {
            if (line.Contains('-'))
            {
                var nums  = line.Split('-');
                var num1 = long.Parse(nums[0]);
                var num2 = long.Parse(nums[1]);
                freshProducts.Add(new ProductRange(num1, num2));

                continue;
            }

            if (string.IsNullOrEmpty(line))
            {
                break;
            }
        }

        var uniqueProducts = new List<ProductRange>();
        var wasUsed = false;
        foreach (var curr in freshProducts)
        {
            wasUsed = false;
            if (uniqueProducts.Any(x => x.Min <= curr.Min && curr.Max <= x.Max))
            {
                continue;
            }

            var lalalala = uniqueProducts.Where(x => (x.Max >= curr.Min && x.Min <= curr.Min) || (x.Min <= curr.Max && x.Max >= curr.Max) || (x.Min > curr.Min && x.Max < curr.Max)).ToList();
            if (lalalala.Count == 0)
            {
                uniqueProducts.Add(curr);
            }
            else
            {
                lalalala.Add(curr);
                var min = lalalala.MinBy(x => x.Min)!.Min;
                var max = lalalala.MaxBy(x => x.Max)!.Max;
                foreach (var product in lalalala)
                {
                    uniqueProducts.Remove(product);
                }
                uniqueProducts.Add(new ProductRange(min, max));
            }
            // var shouldUpdate = uniqueProducts.FirstOrDefault(x => curr.Min < x.Min && curr.Max > x.Min);
            // if (shouldUpdate is not null)
            // {
            //     curr.Max = shouldUpdate.Min - 1;
            //     wasUsed = true;
            // }
            //
            // shouldUpdate = uniqueProducts.FirstOrDefault(x => curr.Max > x.Max && curr.Min < x.Max);
            // if (shouldUpdate is not null)
            // {
            //     curr.Min = shouldUpdate.Max + 1;
            //     wasUsed = true;
            // }
            //
            // // if (!wasUsed)
            // // {

            // // }
        }

        foreach (var curr in uniqueProducts)
        {
            total+= curr.Max - curr.Min + 1;
        }

        Console.WriteLine(total);
    }

    private class ProductRange(long Min, long Max)
    {
        public long Min { get; set; } = Min;
        public long Max { get; set; } = Max;
    }
}