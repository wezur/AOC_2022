List<(string opponent, string me)> winningPairs = new() { ("A", "Y"), ("B", "Z"), ("C", "X") };
List<(string opponent, string me)> drawingPairs = new() { ("A", "X"), ("B", "Y"), ("C", "Z") };
List<(string opponent, string me)> losingPairs = new() { ("A", "Z"), ("B", "X"), ("C", "Y") };

var file = File.ReadLines("input.txt");

int points = 0;


foreach (var line in file)
{
    (string opponent, string me) current = (line.Split(' ')[0], line.Split(' ')[1]);

    points += current.me.GetValue();

    if (winningPairs.Contains(current)) points += 6;
    if (drawingPairs.Contains(current)) points += 3;
}

Console.WriteLine(points);

points = 0;

foreach (var line in file)
{
    (string opponent, string me) current = (line.Split(' ')[0], line.Split(' ')[1]);
    switch (current.me)
    {
        case "X":
            foreach (var pair in losingPairs)
            {
                if (pair.opponent == current.opponent) points += pair.me.GetValue();
            }

            break;
        case "Y":
            points += 3;
            foreach (var pair in drawingPairs)
            {
                if (pair.opponent == current.opponent) points += pair.me.GetValue();
            }

            break;
        case "Z":
            points += 6;
            foreach (var pair in winningPairs)
            {
                if (pair.opponent == current.opponent) points += pair.me.GetValue();
            }

            break;
    }
}

Console.WriteLine(points);

public static class Helper
{
    public static int GetValue(this string str)
    {
        switch (str)
        {
            case "X":
                return 1;
            case "Y":
                return 2;
            case "Z":
                return 3;
            default:
                return 0;
        }
    }
}