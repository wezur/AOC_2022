var file = File.ReadLines("input.txt");

int count = 0;

foreach (var line in file)
{
    (string first, string second) elves = (line.Split(',')[0].GetValue(), line.Split(",")[1].GetValue());
    if ((elves.first.Contains(elves.second) || elves.second.Contains(elves.first)) && elves.first != elves.second)
    {
        count++;
    }
}

Console.WriteLine(count);

count = 0;

foreach (var line in file)
{
    (List<string> first, List<string> second) elves = (line.Split(',')[0].GetValues(), line.Split(",")[1].GetValues());

    foreach (var item in elves.first)
    {
        if (elves.second.Contains(item))
        {
            count++;
            break;
        }
    }
}

Console.WriteLine(count);

public static class Helper
{
    public static string GetValue(this string str)
    {
        var range = str.Split('-');
        var output = string.Empty;
        for (int i = int.Parse(range[0]); i <= int.Parse(range[1]); i++)
        {
            output += i.ToString();
        }
        return output;
    }

    public static List<string> GetValues(this string str)
    {
        var range = str.Split('-');
        var output = new List<string>();
        for (int i = int.Parse(range[0]); i <= int.Parse(range[1]); i++)
        {
            output.Add(i.ToString());
        }
        return output;
    }
}