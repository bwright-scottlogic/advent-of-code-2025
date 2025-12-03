namespace day3;

public class App
{
    public static void Sln1(string input)
    {
        var totalJoltage = 0;
        var banks = input.Split(" ");

        foreach (var bank in banks)
        {
            var joltValues = Array.ConvertAll(bank.ToCharArray(), number => (int)char.GetNumericValue(number));

            var maxBank = 0;
            var secondMaxBank = 0;

            for (var i = 0; i < joltValues.Length; i++)
            {
                if (joltValues[i] > maxBank && i < joltValues.Length - 1)
                {
                    maxBank = joltValues[i];
                    secondMaxBank = 0;
                    continue;
                }

                if (joltValues[i] > secondMaxBank) secondMaxBank = joltValues[i];
            }

            totalJoltage += int.Parse(string.Format("{0}{1}", maxBank, secondMaxBank));
        }

        Console.WriteLine(totalJoltage);
    }

    public static void Sln2(string input)
    {
        long totalJoltage = 0;
        var banks = input.Split(" ");
        var window = 12;

        foreach (var bank in banks)
        {
            var joltValues = bank.Select(c => (int)char.GetNumericValue(c)).ToArray();
            var length = joltValues.Length;

            var result = new List<int>();
            var start = 0;

            for (var i = 0; i < window; i++)
            {
                var remaining = window - i;
                var end = length - remaining;

                var maxJolt = -1;
                var maxPos = start;

                for (var j = start; j <= end; j++)
                    if (joltValues[j] > maxJolt)
                    {
                        maxJolt = joltValues[j];
                        maxPos = j;
                    }

                result.Add(maxJolt);
                start = maxPos + 1;
            }

            totalJoltage += long.Parse(string.Concat(result));
        }


        Console.WriteLine(totalJoltage);
    }
}
