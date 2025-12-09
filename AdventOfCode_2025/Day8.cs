namespace AdventOfCode_2025;

public class Day8
{
    public void Task1()
    {
        var input = File.ReadAllLines("Inputs/day8.txt");

        var junctions = input.Select(x =>
        {
            var nums = x.Split(",");
            return new Point { X = int.Parse(nums[0]), Y = int.Parse(nums[1]), Z = int.Parse(nums[2]) };
        }).ToList();

        var set = new SortedSet<PointsDistance>(new PointsDistanceComparer());

        for (int i = 0; i < junctions.Count; i++)
        {
            for (int j = i+1; j < junctions.Count; j++)
            {
                var distance = GetPointsDistance(junctions[i], junctions[j]);
                set.Add(new PointsDistance(junctions[i], junctions[j], distance));
            }
        }
        var circuits = new List<HashSet<Point>>();

        var counter = 1000;
        foreach (var distance in set)
        {
            var existingCircuit = circuits.Where(x => x.Contains(distance.P1) || x.Contains(distance.P2)).ToList();
            if (existingCircuit.Count == 1)
            {
                existingCircuit.First().Add(distance.P1);
                existingCircuit.First().Add(distance.P2);
            }
            else if (existingCircuit.Count >= 2)
            {
                var newSet = new HashSet<Point>();
                foreach (var circuit in existingCircuit)
                {
                    newSet = newSet.Union(circuit).ToHashSet();
                    circuits.Remove(circuit);
                }

                newSet.Add(distance.P1);
                newSet.Add(distance.P2);
                circuits.Add(newSet);
            }
            else
            {
                circuits.Add([distance.P1, distance.P2]);
            }

            counter--;
            if (counter == 0)
            {
                break;
            }
        }

        var ordered = circuits.OrderByDescending(x => x.Count).Take(3).ToList();

        var total = 1;

        foreach (var circuit in ordered)
        {
            total *= circuit.Count;
        }


        Console.WriteLine(total);
    }

    public void Task2()
    {
        var input = File.ReadAllLines("Inputs/day8.txt");

        var junctions = input.Select(x =>
        {
            var nums = x.Split(",");
            return new Point { X = int.Parse(nums[0]), Y = int.Parse(nums[1]), Z = int.Parse(nums[2]) };
        }).ToList();

        var set = new SortedSet<PointsDistance>(new PointsDistanceComparer());

        for (int i = 0; i < junctions.Count; i++)
        {
            for (int j = i+1; j < junctions.Count; j++)
            {
                var distance = GetPointsDistance(junctions[i], junctions[j]);
                set.Add(new PointsDistance(junctions[i], junctions[j], distance));
            }
        }
        var circuits = new List<HashSet<Point>>();
        
        var lastPoints = GetLastPoints(set, circuits, junctions);
        
        Console.WriteLine(lastPoints.Item1.X * lastPoints.Item2.X);
    }

    private static (Point, Point) GetLastPoints(SortedSet<PointsDistance> set, List<HashSet<Point>> circuits, List<Point> junctions)
    {
        foreach (var distance in set)
        {
            var existingCircuit = circuits.Where(x => x.Contains(distance.P1) || x.Contains(distance.P2)).ToList();
            if (existingCircuit.Count == 1)
            {
                existingCircuit.First().Add(distance.P1);
                existingCircuit.First().Add(distance.P2);
            }
            else if (existingCircuit.Count >= 2)
            {
                var newSet = new HashSet<Point>();
                foreach (var circuit in existingCircuit)
                {
                    newSet = newSet.Union(circuit).ToHashSet();
                    circuits.Remove(circuit);
                }

                newSet.Add(distance.P1);
                newSet.Add(distance.P2);
                circuits.Add(newSet);
            }
            else
            {
                circuits.Add([distance.P1, distance.P2]);
            }

            if (circuits.Count == 1 && circuits.First().Count == junctions.Count)
            {
                return (distance.P1, distance.P2);
            }
        }

        return new ValueTuple<Point, Point>();
    }

    private static double GetPointsDistance(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2) + Math.Pow(p1.Z - p2.Z, 2));
    }

    private struct Point : IEquatable<Point>
    {
        public long X { get; init; }
        public long Y { get; init; }
        public long Z { get; init; }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object? obj)
        {
            return obj is Point other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Z);
        }
    }

    private record PointsDistance(Point P1, Point P2, double Distance);

    private sealed class PointsDistanceComparer : IComparer<PointsDistance>
    {
        public int Compare(PointsDistance? x, PointsDistance? y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (x is null) return -1;
            if (y is null) return 1;

            var cmp = x.Distance.CompareTo(y.Distance);
            if (cmp != 0) return cmp;

            // Tie-breakers so different pairs with same distance are not treated as duplicates
            cmp = x.P1.X.CompareTo(y.P1.X);
            if (cmp != 0) return cmp;

            cmp = x.P1.Y.CompareTo(y.P1.Y);
            if (cmp != 0) return cmp;

            cmp = x.P2.X.CompareTo(y.P2.X);
            if (cmp != 0) return cmp;

            return x.P2.Y.CompareTo(y.P2.Y);
        }
    }
}