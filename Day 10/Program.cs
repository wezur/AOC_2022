using System.Collections.Immutable;

var file = File.ReadLines("input.txt");

int register_X = 1;

List<int> register_X_states = new List<int>();

foreach (var line in file)
{
    if (line == "noop")
    {
        register_X_states.Add(register_X);
        continue;
    }

    int value = int.Parse(line.Split(' ')[1]);

    register_X_states.Add(register_X);
    register_X_states.Add(register_X);
    register_X += value;
}

var i = 0;
foreach (var state in register_X_states)
{

    Console.WriteLine($"{++i} {state}");
}

Console.WriteLine(20 * register_X_states[19] + 60 * register_X_states[59] + 100 * register_X_states[99] + 140 * register_X_states[139] + 180 * register_X_states[179] + 220 * register_X_states[219]);

int counter = 0;
List<string> output = new();
string currentOutput = string.Empty;
foreach (var state in register_X_states)
{
    if (state - counter is >= -1 and <= 1)
    {
        currentOutput += "#";
    }
    else currentOutput += ".";
    counter++;
    if (counter == 40)
    {
        output.Add(currentOutput);
        currentOutput = string.Empty;
        counter = 0;
    }
}

foreach (var line in output)
{
    Console.WriteLine(line);
}