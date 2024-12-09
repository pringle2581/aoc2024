namespace aoc2024.solutions
{
    internal class Day07
    {
        public struct Equation
        {
            public long result;
            public long[] operands;
        }

        static public string[] Solve(string[] input)
        {
            List<Equation> equations = [];
            Parse(input);
            long part1 = Test(1);
            long part2 = Test(2);
            return [part1.ToString(), part2.ToString()];

            void Parse(string[] input)
            {
                foreach (string line in input)
                {
                    string[] split = line.Split(": ");
                    long result = long.Parse(split[0]);
                    long[] operands = split[1].Split(" ").Select(long.Parse).ToArray();
                    equations.Add(new Equation { result = result, operands = operands });
                }
            }

            long Test(int part)
            {
                long sum = 0;
                foreach (var equation in equations)
                {
                    Queue<long> queue = [];
                    queue.Enqueue(equation.operands[0]);

                    for (int i = 1; i < equation.operands.Length; i++)
                    {
                        Queue<long> queue2 = [];
                        while (queue.TryDequeue(out var item))
                        {
                            if (item <= equation.result)
                            {
                                queue2.Enqueue(item + equation.operands[i]);
                                queue2.Enqueue(item * equation.operands[i]);
                                if (part == 2)
                                {
                                    queue2.Enqueue(Convert.ToInt64(item.ToString() + equation.operands[i].ToString()));
                                }
                            }
                        }
                        queue = queue2;
                    }
                    if (queue.Contains(equation.result))
                    {
                        sum += equation.result;
                    }
                }
                return sum;
            }
        }
    }
}
