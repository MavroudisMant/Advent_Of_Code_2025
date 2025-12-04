namespace AdventOfCode_2025;

public class Day3
{
    public void Task1()
    {
        var input = File.ReadAllLines("Inputs/day3.txt");

        var total = 0;

        foreach (var bank in input)
        {
            var max = bank.Max();
            var maxIndex = bank.IndexOf(max);
            if (maxIndex == bank.Length-1)
            {
                var sorted = bank.OrderDescending();
                max = sorted.ElementAt(1);
                maxIndex = bank.IndexOf(max);
            }
            var secondMax = bank[(maxIndex + 1)..].Max();
            var jolt = int.Parse($"{max}{secondMax}");
            total += jolt;
        }

        Console.WriteLine(total);
    }

    public void Task2()
    {
        var input = File.ReadAllLines("Inputs/day3.txt");

        var total = 0L;

        foreach (var bank in input)
        {
            var jolt = long.Parse(GetBiggest(bank, 11));
            total += jolt;
        }

        Console.WriteLine(total);
    }

    private string GetBiggest(string bank, int level)
    {
        var max = bank.Max();
        if (level == 0)
        {
            return max.ToString();
        }
        var maxIndex = bank.IndexOf(max);
        if (bank.Length - 1 - maxIndex < level)
        {
            var tempBank = bank[..(bank.Length-level)];
            max = tempBank.Max();
            maxIndex = bank.IndexOf(max);
        }

        var nextBiggest = GetBiggest(bank[(maxIndex + 1)..], level - 1);
        return $"{max}{nextBiggest}";
    }
}