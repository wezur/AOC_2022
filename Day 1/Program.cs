// See https://aka.ms/new-console-template for more information
var file = File.ReadLines("input.txt");


List<int> elves = new();
int current = 0;

foreach (var line in file)
{
    if (string.IsNullOrEmpty(line))
    {
        elves.Add(current);
        current = 0;
        continue;
    }

    current += int.Parse(line);
}

Console.WriteLine(elves.Max());

var elvesDescending = elves.OrderDescending().ToList();

int sum = 0;
for (int i = 0; i < 3; i++)
{
    sum += elvesDescending[i];
}

Console.WriteLine(sum);