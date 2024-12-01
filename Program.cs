using aoc2024.solutions;

string input = "../../../input/";

static void PrintResults(int day, string[] results)
{
    Console.WriteLine($"Day {day} Part 1: {results[0]}");
    Console.WriteLine($"Day {day} Part 2: {results[1]}\n");
}

PrintResults(1, Day01.Solve(File.ReadAllLines(input + "01")));