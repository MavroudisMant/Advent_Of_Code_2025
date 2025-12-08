namespace AdventOfCode_2025;

public class Day6
{
    public void Task1()
    {
        var input = File.ReadAllLines("Inputs/day6.txt");

        var total = 0L;

        var problems = new List<List<long>>();

        for (var line = 0; line < input.Length-1; line++)
        {
            var nums = input[line].Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

            for (int i = 0; i < nums.Count; i++)
            {
                if (i >= problems.Count)
                {
                    problems.Add([nums[i]]);
                }
                else
                {
                    problems[i].Add(nums[i]);
                }
            }
        }

        var signs = input[^1].Split((char[])null, StringSplitOptions.RemoveEmptyEntries).ToList();

        for (int col = 0; col < signs.Count; col++)
        {
            if (signs[col] == "+")
            {
                var aa = problems[col].Aggregate((x, y) => x + y);
                total += aa;
            }

            if (signs[col] == "*")
            {
                var aa = problems[col].Aggregate((x, y) => x * y);
                total += aa;
            }
        }

        Console.WriteLine(total);
    }

    public void Task2()
    {
        var input = File.ReadAllLines("Inputs/day6.txt");

        var maxLength = input.Max(x => x.Length);

        for (var i = 0; i < input.Length; i++)
        {
            if (input[i].Length == maxLength-1)
            {
                input[i] += " ";
            }
            if (input[i].Length == maxLength-2)
            {
                input[i] += "  ";
            }
        }

        var total = 0L;

        var inputChars = new List<List<char>>();

        foreach (var line in input)
        {
            inputChars.Add(line.ToList());
        }

        var nums = new List<string>();

        string currentNum;
        for (var col = 0; col < inputChars[0].Count; col++)
        {
            currentNum = "";
            for (int i = 0; i < inputChars.Count-1; i++)
            {
                currentNum += inputChars[i][col];
            }
            nums.Add(currentNum.TrimStart().TrimEnd());
        }

        var problems = new List<List<long>>();
        var currentList = new List<long>();

        foreach (var num in nums)
        {
            if (long.TryParse(num, out long result))
            {
                currentList.Add(result);
            }
            else
            {
                problems.Add(currentList);
                currentList = [];
            }
        }
        problems.Add(currentList);//add the last list

        var signs = input[^1].Split((char[])null, StringSplitOptions.RemoveEmptyEntries).ToList();

        for (int col = 0; col < signs.Count; col++)
        {
            if (signs[col] == "+")
            {
                var aa = problems[col].Aggregate((x, y) => x + y);
                total += aa;
            }

            if (signs[col] == "*")
            {
                var aa = problems[col].Aggregate((x, y) => x * y);
                total += aa;
            }
        }

        Console.WriteLine(total);
    }
}