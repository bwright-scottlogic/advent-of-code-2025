namespace day4;

public class App
{
    private static (int x, int y)[] positionsToCheck(int row, int column)
    {
        return
        [
            (row - 1, column - 1), (row - 1, column), (row - 1, column + 1), (row, column - 1), (row, column + 1),
            (row + 1, column - 1), (row + 1, column), (row + 1, column + 1)
        ];
    }

    public static void Sln1(string input)
    {
        var rows = input.Split(" ").Select(s => s.ToCharArray()).ToArray();
        var rowLength = rows[0].Length;
        var columns = rows.Length;

        var accessibleRolls = 0;
        var prevAccessibleRolls = 0;

        for (var row = 0; row < columns; row++)
        for (var column = 0; column < rowLength; column++)
        {
            if (!rows[row][column].Equals('@')) continue;

            var surroundingRolls = 0;
            var surroundingPositions = positionsToCheck(row, column);

            foreach (var position in surroundingPositions)
            {
                if (position.x < 0 || position.x >= rowLength || position.y < 0 || position.y >= columns)
                    continue;

                if (rows[position.x][position.y] == '@')
                    surroundingRolls++;
            }

            if (surroundingRolls < 4)
            {
                accessibleRolls++;
                rows[row][column] = 'x';
            }
        }

        Console.WriteLine(accessibleRolls);
    }

    public static void Sln2(string input)
    {
        var rows = input.Split(" ").Select(s => s.ToCharArray()).ToArray();
        var rowLength = rows[0].Length;
        var columns = rows.Length;

        var accessibleRolls = 0;
        var prevAccessibleRolls = 0;

        while (true)
        {
            for (var row = 0; row < columns; row++)
            for (var column = 0; column < rowLength; column++)
            {
                if (!rows[row][column].Equals('@')) continue;

                var surroundingRolls = 0;
                var surroundingPositions = positionsToCheck(row, column);

                foreach (var position in surroundingPositions)
                {
                    if (position.x < 0 || position.x >= rowLength || position.y < 0 || position.y >= columns)
                        continue;

                    if (rows[position.x][position.y] == '@')
                        surroundingRolls++;
                }

                if (surroundingRolls < 4)
                {
                    accessibleRolls++;
                    rows[row][column] = 'x';
                }
            }

            if (accessibleRolls == prevAccessibleRolls)
                break;

            prevAccessibleRolls = accessibleRolls;
        }

        Console.WriteLine(accessibleRolls);
    }
}
