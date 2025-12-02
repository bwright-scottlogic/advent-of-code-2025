using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace day1;

public class App
{
    private static (int, int) Turn(string direction, int startingPosition, int amount)
    {
        var endingPosition = 0;
        var turns = 0;
        switch (direction)
        {
            case "L":
                endingPosition = startingPosition - amount;
                if (endingPosition < 0 && startingPosition != 0)
                {
                    if (endingPosition <= -100) turns += endingPosition * -1 / 100;

                    turns += 1;
                    endingPosition = 100 + endingPosition;
                }

                break;
            case "R":
                endingPosition = startingPosition + amount;
                if (endingPosition >= 100) turns += endingPosition / 100;

                break;
        }

        endingPosition = Math.Abs(endingPosition % 100);
        //if (endingPosition == 0) turns++;
        Console.WriteLine(endingPosition);

        return (endingPosition, turns);
    }


    public static void PrintSln1(string puzzleInput)
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

    public static void PrintSln2(string puzzleInput)
    {
        var startingPosition = 50;
        var zeros = 0;
        Regex inputMatcher = new(@"([LR])(\d+)");
        var inputs = puzzleInput.Split(["\r\n", "\r", "\n", " "], StringSplitOptions.None);

        foreach (var input in inputs)
        {
            var matchedInput = inputMatcher.Match(input);

            var (endingPosition,
                fullturns) = TurnInfinite(matchedInput.Groups[1].Value, startingPosition,
                IntegerType.FromString(matchedInput.Groups[2].Value));
            zeros += fullturns;
            Console.WriteLine("zeros " + zeros);

            startingPosition = endingPosition;
            Console.WriteLine(IntegerType.FromString(matchedInput.Groups[2].Value) + " ended at " + startingPosition);
        }

        Console.WriteLine(zeros);
    }

    private static (int, int) TurnInfinite(string direction, int startingPosition, int amount)
    {
        var endingPosition = 0;
        var turns = 0;
        switch (direction)
        {
            case "L":
                endingPosition = startingPosition - amount;
                var quotient = endingPosition / -100;

                if (startingPosition == 0 && quotient <= 0)
                {
                    endingPosition = 0;
                    break;
                }

                if (endingPosition <= 0)
                {
                    if (quotient > 0 && startingPosition != 0)
                        if (quotient > 1)
                            turns += quotient + 1;
                        else
                            turns++;
                    if (endingPosition == 0)
                        turns++;
                }

                var mod = (endingPosition % 100 + 100) % 100;
                endingPosition = mod;

                break;
            case "R":
                endingPosition = startingPosition + amount;
                if (endingPosition > 100) turns += endingPosition / 100;
                endingPosition %= 100;
                if (endingPosition == 0)
                    turns++;

                break;
        }

        return (endingPosition, turns);
    }
}
