var file = File.ReadLines("input.txt");

List<char>[] list = new List<char>[9];

Stack<char>[] stack = new Stack<char>[9];

for (int i = 0; i < list.Length; i++)
{
    list[i] = new List<char>();
    stack[i] = new Stack<char>();
}

foreach (var line in file)
{
    if (line.Contains("1")) break;
    for (int i = 1; i < line.Length; i += 4)
    {
        char value = line[i];
        if (!char.IsWhiteSpace(value))
        {
            list[(i-1)/4].Add(value);
        }
    }
}

for (int i = 0; i < list.Length; i++)
{
    list[i].Reverse();
    foreach (var character in list[i])
    {
        stack[i].Push(character);
    }
}

int count = 0;
int destination = 0;
int source = 0;

foreach (var line in file)
{
    if (!line.Contains("move")) continue;
    var values = line.Split(' ');
    count = int.Parse(values[1]);
    source = int.Parse(values[3]);
    destination = int.Parse(values[5]);

    for (int i = 0; i < count; i++)
    {
        stack[destination - 1].Push(stack[source-1].Pop());
    }
}

foreach (var st in stack)
{
    Console.Write(st.Peek());
}

Console.WriteLine();
list = new List<char>[9];

stack = new Stack<char>[9];

for (int i = 0; i < list.Length; i++)
{
    list[i] = new List<char>();
    stack[i] = new Stack<char>();
}

foreach (var line in file)
{
    if (line.Contains("1")) break;
    for (int i = 1; i < line.Length; i += 4)
    {
        char value = line[i];
        if (!char.IsWhiteSpace(value))
        {
            list[(i - 1) / 4].Add(value);
        }
    }
}

for (int i = 0; i < list.Length; i++)
{
    list[i].Reverse();
    foreach (var character in list[i])
    {
        stack[i].Push(character);
    }
}

count = 0; 
destination = 0;
source = 0;

foreach (var line in file)
{
    if (!line.Contains("move")) continue;
    var values = line.Split(' ');
    count = int.Parse(values[1]);
    source = int.Parse(values[3]);
    destination = int.Parse(values[5]);

    List<char> temp = new List<char>();

    for (int i = 0; i < count; i++)
    {
        temp.Add(stack[source - 1].Pop());
    }

    temp.Reverse();

    for (int i = 0; i < count; i++)
    {
        stack[destination - 1].Push(temp[i]);
    }
}


foreach (var st in stack)
{
    Console.Write(st.Peek());
}
