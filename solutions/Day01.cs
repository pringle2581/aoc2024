namespace aoc2024.solutions
{
    internal class Day01
    {
        static public string[] Solve(string[] input)
        {
            int part1 = 0, part2 = 0;
            List<int> left = [], right = [];
            Dictionary<int, int> rightdict = [];
            Parse(input);
            Solve();
            return [part1.ToString(), part2.ToString()];

            void Parse(string[] input)
            {
                foreach (string line in input)
                {
                    string[] num = line.Split("   ");
                    left.Add(int.Parse(num[0]));
                    right.Add(int.Parse(num[1]));
                    rightdict[int.Parse(num[1])] = 1 + (rightdict.TryGetValue(int.Parse(num[1]), out int result) ? result : 0);
                }
            }

            void Solve()
            {
                left.Sort();
                right.Sort();
                for (int i = 0; i < left.Count; i++)
                {
                    part1 += Math.Abs(left[i] - right[i]);
                    part2 += left[i] * (rightdict.TryGetValue(left[i], out int result) ? result : 0);
                }
            }
        }
    }
}
