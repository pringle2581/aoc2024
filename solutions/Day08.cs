namespace aoc2024.solutions
{
    internal class Day08
    {
        static public string[] Solve(string[] input)
        {
            string[] sample = "............\r\n........0...\r\n.....0......\r\n.......0....\r\n....0.......\r\n......A.....\r\n............\r\n............\r\n........A...\r\n.........A..\r\n............\r\n............".Split("\r\n");
            int mapsize;
            Dictionary<char, List<(int, int)>> antennae = [];
            Parse(input);
            int part1 = FindAntinodes(1);
            int part2 = FindAntinodes(2);
            return [part1.ToString(), part2.ToString()];

            void Parse(string[] input)
            {
                int linenum = 0;
                foreach (string line in input)
                {
                    int charnum = 0;
                    foreach (char character in line)
                    {
                        if (character != '.')
                        {
                            var list = antennae.GetValueOrDefault(character, []);
                            list.Add((charnum, linenum));
                            antennae[character] = list;
                        }
                        charnum++;
                    }
                    linenum++;
                }
                mapsize = linenum;
            }

            int FindAntinodes(int part)
            {
                HashSet<(int, int)> antinodes = [];
                foreach (var frequency in antennae)
                {
                    if (part == 2)
                    {
                        foreach (var pos in frequency.Value)
                        {
                            antinodes.Add(pos);
                        }
                    }
                    for (int i = 0; i < frequency.Value.Count; i++)
                    {
                        for (int j = 0; j < frequency.Value.Count; j++)
                        {

                            if (i != j)
                            {
                                int xdiff = frequency.Value[i].Item1 - frequency.Value[j].Item1;
                                int ydiff = frequency.Value[i].Item2 - frequency.Value[j].Item2;
                                int x = frequency.Value[i].Item1 + xdiff;
                                int y = frequency.Value[i].Item2 + ydiff;
                                if (part == 1)
                                {
                                    if (x >= 0 && x < mapsize && y >= 0 && y < mapsize)
                                    {
                                        antinodes.Add((x, y));
                                    }
                                }
                                else {
                                    while (x >= 0 && x < mapsize && y >= 0 && y < mapsize)
                                    {
                                        antinodes.Add((x, y));
                                        x += xdiff;
                                        y += ydiff;
                                    }
                                }
                            }
                        }
                    }
                }
                return antinodes.Count;
            }
        }
    }
}
