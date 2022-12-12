var file = File.ReadLines("input.txt");

var table = new int[file.Count(), file.ElementAt(0).Length];

for (var i = 0; i < table.GetLength(1); i++)
{
    var line = file.ElementAt(i);
    for (var j = 0; j < file.ElementAt(i).Length; j++)
    {
        table[i, j] = int.Parse(line[j].ToString());
    }
}

var count = 0;

for (var i = 1; i < table.GetLength(1) - 1; i++)
{
    for (var j = 1; j < table.GetLength(1) - 1; j++)
    {
        var current = table[i, j];
        var maxLeft = 0;
        var maxRight = 0;
        var maxTop = 0;
        var maxBottom = 0;
        for (var k = 0; k < j; k++)
        {
            var value = table[i, k];
            if (value > maxLeft) maxLeft = value;
        }

        for (var k = j + 1; k < table.GetLength(1); k++)
        {
            var value = table[i, k];
            if (value > maxRight) maxRight = value;
        }

        for (var k = 0; k < i; k++)
        {
            var value = table[k, j];
            if (value > maxTop) maxTop = value;
        }

        for (var k = i + 1; k < table.GetLength(1); k++)
        {
            var value = table[k, j];
            if (value > maxBottom) maxBottom = value;
        }

        if (current > maxLeft || current > maxRight || current > maxBottom || current > maxTop)
        {
            count++;
        }
    }
}


count = count + 4 * table.GetLength(0) - 4;

Console.WriteLine(count);

int maxValue = 0;

for (var i = 1; i < table.GetLength(1) - 1; i++)
{
    for (var j = 1; j < table.GetLength(1) - 1; j++)
    {
        var current = table[i, j];
        var maxLeft = 0;
        var maxRight = 0;
        var maxTop = 0;
        var maxBottom = 0;
        for (var k = j - 1; k >= 0; k--)
        {
            var value = table[i, k];
            maxLeft++;
            if (value >= current) break;
        }

        for (var k = j + 1; k < table.GetLength(1); k++)
        {
            var value = table[i, k];
            maxRight++;
            if (value >= current) break;
        }

        for (var k = i - 1; k >= 0; k--)
        {
            var value = table[k, j];
            maxTop++;
            if (value >= current) break;
        }

        for (var k = i + 1; k < table.GetLength(1); k++)
        {
            var value = table[k, j];
            maxBottom++;
            if (value >= current) break;
        }

        var finalValue = maxLeft * maxRight * maxTop * maxBottom;
        maxValue = finalValue > maxValue ? finalValue : maxValue;
    }
}

Console.WriteLine(maxValue);