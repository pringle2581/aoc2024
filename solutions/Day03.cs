using System.Text.RegularExpressions;

namespace aoc2024.solutions
{
    internal class Day03
    {
        static public string[] Solve(string[] input)
        {
            string pt1 = string.Join("", input) + "do()";
            int part1 = Multiply(pt1);
            string pt2 = Regex.Replace(pt1, "don't\\(\\).*?do\\(\\)", "");
            int part2 = Multiply(pt2);
            return [part1.ToString(), part2.ToString()];

            static int Multiply(string input)
            {
                int sum = 0;
                foreach (Match match in Regex.Matches(input, "mul\\(\\d{1,3},\\d{1,3}\\)"))
                {
                    MatchCollection factors = Regex.Matches(match.Value, "\\d+");
                    sum += int.Parse(factors[0].Value) * int.Parse(factors[1].Value);
                }
                return sum;
            }
        }
    }
}
