namespace aoc2024.solutions
{
    internal class Day05
    {
        static public string[] Solve(string[] input)
        {
            int part1 = 0, part2 = 0;
            List<int[]> rules = [], updates = [];
            Parse(input);
            foreach (int[] update in updates)
            {
                if (Validate(update))
                {
                    part1 += update[update.Length / 2];
                }
                else
                {
                    part2 += update[update.Length / 2];
                }
            }
            return [part1.ToString(), part2.ToString()];

            void Parse(string[] input)
            {
                foreach (string line in input)
                {
                    if (line.Contains('|'))
                    {
                        rules.Add(line.Split("|").Select(int.Parse).ToArray());
                    }
                    else if (line.Contains(','))
                    {
                        updates.Add(line.Split(",").Select(int.Parse).ToArray());
                    }
                }
            }

            bool Validate(int[] update)
            {
                bool correct = true;
                bool complete = false;
                while (!complete) {
                    bool changed = false;
                    foreach (int[] rule in rules)
                    {
                        if (update.Contains(rule[0]) && update.Contains(rule[1]))
                        {
                            if (Array.IndexOf(update, rule[0]) > Array.IndexOf(update, rule[1]))
                            {
                                correct = false;
                                changed = true;
                                (update[Array.IndexOf(update, rule[0])], update[Array.IndexOf(update, rule[1])]) = (update[Array.IndexOf(update, rule[1])], update[Array.IndexOf(update, rule[0])]);
                            }
                        }
                    }
                    if (!changed)
                    {
                        complete = true;
                    }
                }
                return correct;
            }
        }
    }
}
