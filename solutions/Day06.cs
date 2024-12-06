namespace aoc2024.solutions
{
    internal class Day06
    {
        static public string[] Solve(string[] input)
        {
            int mapsize;
            HashSet<(int, int)> obstructions = [];
            (int, int) start = (0, 0);
            Parse(input);
            HashSet<(int, int)> path = GetInitPath();
            int part1 = path.Count;
            int part2 = FindLoops();
            return [part1.ToString(), part2.ToString()];

            void Parse(string[] input)
            {
                int linenum = 0;
                foreach (string line in input)
                {
                    int charnum = 0;
                    foreach (char character in line)
                    {
                        if (character == '#')
                        {
                            obstructions.Add((charnum, linenum));
                        }
                        else if (character == '^')
                        {
                            start = (charnum, linenum);
                        }
                        charnum++;
                    }
                    linenum++;
                }
                mapsize = linenum;
            }

            HashSet<(int, int)> GetInitPath()
            {
                HashSet<(int, int)> path = [];
                HashSet<((int, int), int)> rawpath = GetPath().Item1;
                foreach (var entry in rawpath)
                {
                    path.Add(entry.Item1);
                }
                return path;
            }

            (HashSet<((int, int), int)>, bool) GetPath()
            {
                (int, int) guard = start;
                int facing = 0;
                HashSet<((int, int), int)> path = [];
                while (true)
                {
                    (int, int) next = (facing % 4) switch
                    {
                        0 => (guard.Item1, guard.Item2 - 1),
                        1 => (guard.Item1 + 1, guard.Item2),
                        2 => (guard.Item1, guard.Item2 + 1),
                        3 => (guard.Item1 - 1, guard.Item2),
                    };
                    if (obstructions.Contains(next))
                    {
                        facing++;
                    }
                    else
                    {
                        if (!path.Add((guard, facing % 4)))
                        {
                            return (path, true);
                        }
                        guard = next;
                        if (guard.Item1 < 0 || guard.Item1 >= mapsize || guard.Item2 < 0 || guard.Item2 >= mapsize)
                        {
                            return (path, false);
                        }
                    }
                }
            }

            int FindLoops()
            {
                int sum = 0;
                foreach ((int, int) pos in path)
                {
                    obstructions.Add((pos.Item1, pos.Item2));
                    if (GetPath().Item2)
                    {
                        sum++;
                    }
                    obstructions.Remove((pos.Item1, pos.Item2));
                }
                return sum;
            }
        }
    }
}
