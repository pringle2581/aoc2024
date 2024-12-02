namespace aoc2024.solutions
{
    internal class Day02
    {
        static public string[] Solve(string[] input)
        {
            int part1 = 0, part2 = 0;
            List<List<int>> reports = Parse(input);
            foreach (List<int> report in reports)
            {
                if (CheckSafety(report))
                {
                    part1 += 1;
                    part2 += 1;
                }
                else if (CheckDampenedSafety(report))
                {
                    part2 += 1;
                }
            }
            return [part1.ToString(), part2.ToString()];

            bool CheckDampenedSafety(List<int> report)
            {
                bool safe = false;
                for (int i = 0; i < report.Count; i++)
                {
                    var copy = report.ToList();
                    copy.RemoveAt(i);
                    if (CheckSafety(copy))
                    {
                        safe = true;
                    }
                }
                return safe;
            }

            bool CheckSafety(List<int> report)
            {
                bool increasing = false, decreasing = false;
                for (int i = 1; i < report.Count; i++)
                {
                    int diff = report[i] - report[i - 1];
                    if (diff > 3 || diff < -3 || diff == 0)
                    {
                        return false;
                    }
                    if (diff >= 1)
                    {
                        increasing = true;
                    }
                    else if (diff <= 1)
                    {
                        decreasing = true;
                    }
                    if (increasing == true && decreasing == true)
                    {
                        return false;
                    }
                }
                return true;
            }

            List<List<int>> Parse(string[] input)
            {
                List<List<int>> list = [];
                foreach (string line in input)
                {
                    List<int> array = line.Split(" ").Select(int.Parse).ToList();
                    list.Add(array);
                }
                return list;
            }
        }
    }
}