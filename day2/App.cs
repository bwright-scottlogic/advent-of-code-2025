using System.Text.RegularExpressions;

namespace day2;

public class App
{
    public static void FindRepeatingNumber(string inputs)
    {
        var inputRanges = inputs.Split(',');
        var patternMatcher = new Regex(@"^(\d+)\1+$");
        long repetitiveNumbers = 0;

        foreach (var input in inputRanges)
        {
            var limits = input.Split('-');
            var low = long.Parse(limits[0]);
            var high = long.Parse(limits[1]);

            for (var i = low; i <= high; i++)
            {
                var matchedPattern = patternMatcher.Match(i.ToString());
                if (matchedPattern.Success)
                    repetitiveNumbers += i;
            }
        }

        Console.WriteLine(repetitiveNumbers);
    }
}
