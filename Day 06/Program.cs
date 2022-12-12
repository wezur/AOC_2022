var file = File.ReadLines("input.txt");

var line = file.ElementAt(0);

List<char> chars = new List<char>();


for (int i = 0; i < 4; i++)
{
    chars.Add(line[i]);
}

for (int i = 3; i < line.Length; i++)
{
    if (chars.Distinct().Count() == 4)
    {
        Console.WriteLine(i+1);
        break;
    }
    chars.RemoveAt(0);
    chars.Add(line[i+1]);
}

chars = new List<char>();

for (int i = 0; i < 14; i++)
{
    chars.Add(line[i]);
}

for (int i = 13; i < line.Length; i++)
{
    if (chars.Distinct().Count() == 14)
    {
        Console.WriteLine(i + 1);
        break;
    }
    chars.RemoveAt(0);
    chars.Add(line[i + 1]);
}