using aoc2024.solutions;

string input = "../../../input/";

static void PrintResults(string day, string[] results)
{
    Console.WriteLine($"Day {day} Part 1: {results[0]}");
    Console.WriteLine($"Day {day} Part 2: {results[1]}\n");
}

PrintResults("01", Day01.Solve(File.ReadAllLines(input + "01")));
PrintResults("02", Day02.Solve(File.ReadAllLines(input + "02")));
PrintResults("03", Day03.Solve(File.ReadAllLines(input + "03")));
PrintResults("04", Day04.Solve(File.ReadAllLines(input + "04")));
PrintResults("05", Day05.Solve(File.ReadAllLines(input + "05")));
PrintResults("06", Day06.Solve(File.ReadAllLines(input + "06")));
PrintResults("07", Day07.Solve(File.ReadAllLines(input + "07")));
PrintResults("08", Day08.Solve(File.ReadAllLines(input + "08")));
PrintResults("09", Day09.Solve(File.ReadAllLines(input + "09")));
