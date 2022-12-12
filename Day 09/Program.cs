(int X, int Y) tailPos = (0, 0);
(int X, int Y) headPos = (0, 0);

List<(int X, int Y)> tailPoses = new() { tailPos };

var file = File.ReadLines("input.txt");

foreach (var line in file)
{
    (char direction, int length) move = (line.Split(' ')[0][0], int.Parse(line.Split(" ")[1]));
    switch (move.direction)
    {
        case 'R':
            for (int i = 0; i < move.length; i++)
            {
                headPos.X++;
                tailPos = CheckIntegrity(tailPos, headPos);
                tailPoses.Add(tailPos);
            }
            break;
        case 'L':
            for (int i = 0; i < move.length; i++)
            {
                headPos.X--;
                tailPos = CheckIntegrity(tailPos, headPos);
                tailPoses.Add(tailPos);
            }
            break;
        case 'U':
            for (int i = 0; i < move.length; i++)
            {
                headPos.Y++;
                tailPos = CheckIntegrity(tailPos, headPos);
                tailPoses.Add(tailPos);
            }
            break;
        case 'D':
            for (int i = 0; i < move.length; i++)
            {
                headPos.Y--;
                tailPos = CheckIntegrity(tailPos, headPos);
                tailPoses.Add(tailPos);
            }
            break;
    }
}

Console.WriteLine(tailPoses.Distinct().Count());

(int X, int Y) CheckIntegrity((int X, int Y) tailPos, (int X, int Y) headPos)
{
    (int X, int Y) diff = (headPos.X - tailPos.X, headPos.Y - tailPos.Y);
    if ((diff.X is >= -1 and <= 1) && (diff.Y is >= -1 and <= 1)) return tailPos;
    if (diff.X == 0)
    {
        if (diff.Y > 0)
        {
            tailPos.Y++;
        }
        else tailPos.Y--;
    }

    if (diff.Y == 0)
    {
        if (diff.X > 0)
        {
            tailPos.X++;
        } else tailPos.X--;
    }

    if (diff.X == 0 || diff.Y == 0) return tailPos;
    switch (diff.X)
    {
        case > 0:
            tailPos.X++;
            break;
        case < 0:
            tailPos.X--;
            break;
    }

    switch (diff.Y)
    {
        case > 0:
            tailPos.Y++;
            break;
        case < 0:
            tailPos.Y--;
            break;
    }

    return tailPos;
}

(int X, int Y)[] CheckIntegrity2((int X, int Y)[] ropePoses)
{
    for (var i = 0; i < ropePoses.Length - 1; i++)
    {
        (int X, int Y) diff = (ropePoses[i].X - ropePoses[i + 1].X, ropePoses[i].Y - ropePoses[i + 1].Y);
        if ((diff.X is >= -1 and <= 1) && (diff.Y is >= -1 and <= 1)) continue;
        if (diff.X == 0)
        {
            if (diff.Y > 0)
            {
                ropePoses[i + 1].Y++;
            }
            else ropePoses[i + 1].Y--;
        }

        if (diff.Y == 0)
        {
            if (diff.X > 0)
            {
                ropePoses[i + 1].X++;
            }
            else ropePoses[i + 1].X--;
        }

        if (diff.X == 0 || diff.Y == 0) continue;
        switch (diff.X)
        {
            case > 0:
                ropePoses[i + 1].X++;
                break;
            case < 0:
                ropePoses[i + 1].X--;
                break;
        }

        switch (diff.Y)
        {
            case > 0:
                ropePoses[i + 1].Y++;
                break;
            case < 0:
                ropePoses[i + 1].Y--;
                break;
        }
    }
    return ropePoses;
}

(int X, int Y)[] ropePoses = new (int, int)[10];
tailPoses = new List<(int X, int Y)>() { ropePoses[9] };

for (int i = 0; i < ropePoses.Length; i++)
{
    ropePoses[i].X = 0;
    ropePoses[i].Y = 0;
}

foreach (var line in file)
{
    (char direction, int length) move = (line.Split(' ')[0][0], int.Parse(line.Split(" ")[1]));
    switch (move.direction)
    {
        case 'R':
            for (var i = 0; i < move.length; i++)
            {
                ropePoses[0].X++;
                ropePoses = CheckIntegrity2(ropePoses);
                tailPoses.Add(ropePoses[9]);
            }
            break;
        case 'L':
            for (var i = 0; i < move.length; i++)
            {
                ropePoses[0].X--;
                ropePoses = CheckIntegrity2(ropePoses);
                tailPoses.Add(ropePoses[9]);
            }
            break;
        case 'U':
            for (var i = 0; i < move.length; i++)
            {
                ropePoses[0].Y++;
                ropePoses = CheckIntegrity2(ropePoses);
                tailPoses.Add(ropePoses[9]);
            }
            break;
        case 'D':
            for (var i = 0; i < move.length; i++)
            {
                ropePoses[0].Y--;
                ropePoses = CheckIntegrity2(ropePoses);
                tailPoses.Add(ropePoses[9]);
            }
            break;
    }
}

Console.WriteLine(tailPoses.Distinct().Count());
