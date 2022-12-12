using System.Text;

var file = File.ReadLines("input.txt");

int sum = 0;

foreach (var line in file)
{
    (string first, string second) compartments = (line[..(line.Length/2)], line[(line.Length/2)..]);
    foreach (var item in compartments.first)
    {
        if (compartments.second.Contains(item))
        {
            sum += item.ToString().GetValue();
            break;
        }
    }
}
Console.WriteLine(sum);

sum = 0;

for (int i = 0; i < file.Count(); i += 3)
{
    (string first, string second, string third) elves = (file.ElementAt(i), file.ElementAt(i + 1),
        file.ElementAt(i + 2));
    foreach (var item in elves.first)
    {
        if (elves.second.Contains(item) && elves.third.Contains(item))
        {
            sum += item.ToString().GetValue();
            break;
        }
    }
}

Console.WriteLine(sum);

public static class Helper
{
    public static int GetValue(this string str)
    {
        var value = Encoding.ASCII.GetBytes(str)[0];
        if (value is > 64 and < 91)
        {
            return value - 38;
        }

        if (value is > 96 and < 123)
        {
            return value - 96;
        }
        return 0;
    }
}