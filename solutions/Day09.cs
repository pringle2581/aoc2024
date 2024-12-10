namespace aoc2024.solutions
{
    internal class Day09
    {
        static public string[] Solve(string[] input)
        {
            List<int> disk = Parse(input[0]);
            List<int> disk1 = Compact(disk);
            long part1 = Checksum(disk1);
            List<int> disk2 = MoveFiles(disk);
            long part2 = Checksum(disk2);
            return [part1.ToString(), part2.ToString()];

            List<int> Parse(string input)
            {
                List<int> disk = [];
                int id = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    int character;
                    int length = input[i] - '0';
                    if (i % 2 == 0)
                    {
                        character = id;
                        id++;
                    }
                    else
                    {
                        character = -1;
                    }
                    for (int j = 1; j <= length; j++)
                    {
                        disk.Add(character);
                    }
                }
                return disk;
            }

            List<int> Compact(List<int> diskin)
            {
                List<int> disk = new(diskin);
                int fwd = 0;
                for (int bwd = disk.Count - 1; bwd > fwd; bwd--)
                {
                    if (disk[bwd] != -1)
                    {
                        while (disk[fwd] != -1 && fwd < bwd)
                        {
                            fwd++;
                        }
                        (disk[fwd], disk[bwd]) = (disk[bwd], disk[fwd]);
                    }
                }
                return disk;
            }

            List<int> MoveFiles(List<int> diskin)
            {
                List<int> disk = new(diskin);
                for (int bwd = disk.Count - 1; bwd > 0; bwd--)
                {
                    if (disk[bwd] != -1)
                    {
                        int value = disk[bwd];
                        int bwdsize = 0;
                        while (bwd - bwdsize >= 0 && disk[bwd - bwdsize] == disk[bwd])
                        {
                            bwdsize++;
                        }
                        int free = FindFree(bwd, bwdsize);
                        if (free > 0)
                        {
                            for (int i = 0; i < bwdsize; i++)
                            {
                                disk[free + i] = value;
                                disk[bwd - i] = -1;
                            }
                        }
                        bwd -= bwdsize - 1;
                    }
                }
                return disk;

                int FindFree(int end, int size)
                {
                    int fwd = 0;
                    while (fwd < end)
                    {
                        if (disk[fwd] != -1)
                        {
                            fwd++;
                        }
                        else
                        {
                            int fwdsize = 1;
                            while (fwd + fwdsize < disk.Count - 1)
                            {
                                if (disk[fwd+fwdsize] == -1)
                                {
                                    fwdsize++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (fwdsize >= size)
                            {
                                return fwd;
                            }
                            else
                            {
                                fwd += fwdsize;
                            }
                        }
                    }
                    return 0;
                }
            }

            long Checksum(List<int> disk)
            {
                long sum = 0;
                for (int i = 0; i < disk.Count; i++)
                {
                    if (disk[i] != -1)
                    {
                        sum += i * disk[i];
                    }
                }
                return sum;
            }
        }
    }
}
