namespace AdventOfCode_2025;

public class Day1
{
    public void Task1()
    {
        var input = File.ReadAllLines("Inputs/day1.txt");

        var currentPoint = 50;

        var zerosCount = 0;
        var loopCount = 0;

        foreach (var line in input)
        {
            var direction = line[..1];
            var num = int.Parse(line[1..]);

            if (num > 99)
            {
                var loops = num / 100;
                loopCount += loops;
                num = num % 100;
            }

            var prev = currentPoint;

            currentPoint += direction == "R" ? num : -num;

            if (currentPoint < 0)
            {
                currentPoint = 100 + currentPoint;
                if (currentPoint != 0 && prev != 0)
                {
                    loopCount++;
                }
            }

            if (currentPoint > 99)
            {
                currentPoint -= 100;
                if (currentPoint != 0 && prev != 0)
                {
                    loopCount++;
                }
            }

            if (currentPoint == 0)
            {
                zerosCount++;
            }

            Console.WriteLine(currentPoint);
        }

        Console.WriteLine($"Zeros : {zerosCount}");
        Console.WriteLine($"Loop count: {loopCount}");
        Console.WriteLine($"Total : {zerosCount+loopCount}");
    }
}