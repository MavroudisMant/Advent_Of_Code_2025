using System.Text;

namespace AdventOfCode_2025;

public class Day2
{
    public void Task1()
    {
        var input = File.ReadAllText("Inputs/day2.txt");
        var ranges = input.Split(",");

        var sb = new StringBuilder();
        var total = 0L;

        foreach (var range in ranges)
        {
            var nums = range.Split("-");
            var start = long.Parse(nums[0]);
            var end = long.Parse(nums[1]);

            for (var i = start; i <= end; i++)
            {
                if (CheckingTask1(i, sb))
                {
                    total += i;
                }
            }
        }

        Console.WriteLine(total);
    }

    private static bool CheckingTask1(long i, StringBuilder sb)
    {
        var stringNum = i.ToString();
        if (stringNum.Length % 2 != 0)
        {
            return false;
        }
        var size = stringNum.Length / 2;
        var seq = stringNum[..size];
        var mult = (stringNum.Length / seq.Length);
        int requiredCapacity = seq.Length * mult;
        if (sb.Capacity < requiredCapacity)
        {
            sb.Capacity = requiredCapacity;
        }
        sb.Clear();

        for (int j = 0; j < mult; j++)
            sb.Append(seq);

        var checkNum = sb.ToString();
        if (checkNum == stringNum)
        {
            return true;
        }

        return false;
    }

    public void Task2()
    {
        var input = File.ReadAllText("Inputs/day2.txt");
        var ranges = input.Split(",");

        var sb = new StringBuilder();
        var total = 0L;

        foreach (var range in ranges)
        {
            var nums = range.Split("-");
            var start = long.Parse(nums[0]);
            var end = long.Parse(nums[1]);

            for (var i = start; i <= end; i++)
            {
                if (CheckingTask2(i, sb))
                {
                    total += i;
                }
            }
        }

        Console.WriteLine(total);
    }

    private static bool CheckingTask2(long i, StringBuilder sb)
    {
        var stringNum = i.ToString();
        for (var size = 1; size <= stringNum.Length / 2; size++)
        {
            var seq = stringNum[..size];
            var mult = (stringNum.Length / seq.Length);
            int requiredCapacity = seq.Length * mult;
            if (sb.Capacity < requiredCapacity)
            {
                sb.Capacity = requiredCapacity;
            }

            sb.Clear();

            for (int j = 0; j < mult; j++) sb.Append(seq);

            var checkNum = sb.ToString();
            if (checkNum == stringNum)
            {
                return true;
            }
        }

        return false;
    }
}