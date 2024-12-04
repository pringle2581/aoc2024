namespace aoc2024.solutions
{
    internal class Day04
    {
        static public string[] Solve(string[] input)
        {
            int part1 = 0, part2 = 0;
            HashSet<(int, int)> x = [], m = [], a = [], s = [];
            Dictionary<string, (int, int)> dirs = new()
            {
                { "N", (0, -1) },
                { "NE", (1, -1) },
                { "E", (1, 0) },
                { "SE", (1, 1) },
                { "S", (0, 1) },
                { "SW", (-1, 1) },
                { "W", (-1, 0) },
                { "NW", (-1, -1) },
            };
            Parse(input);
            CountXMAS();
            CountX_MAS();
            return [part1.ToString(), part2.ToString()];

            void Parse(string[] input)
            {
                int linenum = 0;
                foreach (string line in input)
                {
                    int letternum = 0;
                    foreach (char letter in line)
                    {
                        switch (letter)
                        {
                            case 'X':
                                x.Add((letternum, linenum));
                                break;
                            case 'M':
                                m.Add((letternum, linenum));
                                break;
                            case 'A':
                                a.Add((letternum, linenum));
                                break;
                            case 'S':
                                s.Add((letternum, linenum));
                                break;
                        }
                        letternum++;
                    }
                    linenum++;
                }
            }

            void CountXMAS()
            {
                foreach ((int, int) xloc in x)
                {
                    foreach ((int, int) dir in dirs.Values)
                    {
                        (int, int) pos = xloc;
                        pos.Item1 += dir.Item1;
                        pos.Item2 += dir.Item2;
                        if (m.Contains(pos))
                        {
                            pos.Item1 += dir.Item1;
                            pos.Item2 += dir.Item2;
                            if (a.Contains(pos))
                            {
                                pos.Item1 += dir.Item1;
                                pos.Item2 += dir.Item2;
                                if (s.Contains(pos))
                                {
                                    part1++;
                                }
                            }
                        }
                    }
                }
            }

            void CountX_MAS()
            {
                foreach ((int, int) pos in a)
                {
                    (int, int) ne = (pos.Item1 + dirs["NE"].Item1, pos.Item2 + dirs["NE"].Item2);
                    (int, int) sw = (pos.Item1 + dirs["SW"].Item1, pos.Item2 + dirs["SW"].Item2);
                    (int, int) nw = (pos.Item1 + dirs["NW"].Item1, pos.Item2 + dirs["NW"].Item2);
                    (int, int) se = (pos.Item1 + dirs["SE"].Item1, pos.Item2 + dirs["SE"].Item2);
                    if ((m.Contains(ne) && s.Contains(sw)) || (s.Contains(ne) && m.Contains(sw)))
                    {
                        if ((m.Contains(nw) && s.Contains(se)) || (s.Contains(nw) && m.Contains(se)))
                        {
                            part2++;
                        }
                    }
                }
            }
        }
    }
}
