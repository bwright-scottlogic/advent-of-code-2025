using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace day1;

public class App
{
    public static void PrintSln(string puzzleInput)
    {
        var startingPosition = 50;
        var zeros = 0;
        Regex inputMatcher = new(@"([LR])(\d+)");
        var inputs = puzzleInput.Split(["\r\n", "\r", "\n", " "], StringSplitOptions.None);

        foreach (var input in inputs)
        {
            var matchedInput = inputMatcher.Match(input);

            var endingPosition = matchedInput.Groups[1].Value == "L"
                ? startingPosition - IntegerType.FromString(matchedInput.Groups[2].Value)
                : startingPosition + IntegerType.FromString(matchedInput.Groups[2].Value);

            if (endingPosition % 100 == 0) zeros++;

            startingPosition = endingPosition;
        }

        Console.WriteLine(zeros);
    }
}
