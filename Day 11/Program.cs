using System.Numerics;

List<Monkey> monkeys = new List<Monkey>
{
    new Monkey() // Monkey 0
    {

        items = new List<Worry> { new Worry(77), new Worry(69), new Worry(76), new Worry(77), new Worry(50), new Worry(58) },
        operation = (Worry item) =>
        {
            item.multipliers.Add(11);
            item.multipliers = item.multipliers.Distinct().ToList();
            return item;
        },
        test = (Worry item) =>
        {
            if (item.addition % 11 != 0) return false;
            return item.multipliers.Contains(11);
        },
        throwIfTrue = 1,
        throwIfFalse = 5
    },
    new Monkey() // Monkey 1
    {
        items = new List<Worry> { new Worry(75), new Worry(70), new Worry(82), new Worry(83), new Worry(96), new Worry(64), new Worry(62) },
        operation = (Worry item) =>
        {
            item.addition += 8;
            return item;
        },
        test = (Worry item) =>
        {
            if (item.addition % 17 != 0) return false;
            return item.multipliers.Contains(17);
        },
        throwIfTrue = 5,
        throwIfFalse = 6
    },
    new Monkey() // Monkey 2
    {
        items = new List<Worry> { new Worry(53) },
        operation = (Worry item) =>
        {
            item.multipliers.Add(3);
            item.multipliers = item.multipliers.Distinct().ToList();
            return item;
        },
        test = (Worry item) =>
        {
            if (item.addition % 2 != 0) return false;
            return item.multipliers.Contains(2);
        },
        throwIfTrue = 0,
        throwIfFalse = 7
    },
    new Monkey() // Monkey 3
    {
        items = new List<Worry> { new Worry(85), new Worry(64), new Worry(93), new Worry(64), new Worry(99) },
        operation = (Worry item) =>
        {
            item.addition += 4;
            return item;
        },
        test = (Worry item) =>
        {
            if (item.addition % 7 != 0)
                return false;
            return item.multipliers.Contains(7);
        },
        throwIfTrue = 7,
        throwIfFalse = 2
    },
    new Monkey() // Monkey 4
    {
        items = new List<Worry> { new Worry(61), new Worry(92), new Worry(71) },
        operation = (Worry item) =>
        {
            BigInteger value = 0;
            item.multipliers.AddRange(item.multipliers);
            item.Update();
            var copy = item.multipliers;
            foreach (var x in copy)
            {
                value *= x;
            }
            item.addition = item.addition + 2*value*item.addition + item.addition*item.addition;
            return item;
        },
        test = (Worry item) =>
        {
            if (item.addition % 3 != 0)
                return false;
            return item.multipliers.Contains(3);
        },
        throwIfTrue = 2,
        throwIfFalse = 3
    },
    new Monkey() // Monkey 5
    {
        items = new List<Worry> { new Worry(79), new Worry(73), new Worry(50), new Worry(90) },
        operation = (Worry item) => { item.addition += 2; return item; },
        test = (Worry item) =>
        {
            if (item.addition % 11 != 0)
                return false;
            return item.multipliers.Contains(11);
        },
        throwIfTrue = 4,
        throwIfFalse = 6
    },
    new Monkey() // Monkey 6
    {
        items = new List<Worry> { new Worry(50), new Worry(89) },
        operation = (Worry item) => { item.addition += 3; return item; },
        test = (Worry item) =>
        {
            if (item.addition % 13 != 0)
                return false;
            return item.multipliers.Contains(13);
        },
        throwIfTrue = 4,
        throwIfFalse = 3
    },
    new Monkey() // Monkey 7
    {
        items = new List<Worry> { new Worry(83), new Worry(56), new Worry(64), new Worry(58), new Worry(93), new Worry(91), new Worry(56), new Worry(65) },
        operation = (Worry item) => { item.addition += 5; return item; },
        test = (Worry item) =>
        {
            if (item.addition % 19 != 0)
                return false;
            return item.multipliers.Contains(19);
        },
        throwIfTrue = 1,
        throwIfFalse = 0
    },
};



//List<Monkey> monkeys = new List<Monkey>
//{
//    new Monkey() // Monkey 0
//    {
//        items = new List<BigBigIntegeriger> { 79, 98 },
//        operation = (BigBigIntegeriger item) => item * 19,
//        test = (BigBigIntegeriger item) => item % 23 == 0,
//        throwIfTrue = 2,
//        throwIfFalse = 3
//    },
//    new Monkey() // Monkey 1
//    {
//        items = new List<BigBigIntegeriger> { 54, 65, 75, 74 },
//        operation = (BigBigIntegeriger item) => item + 6,
//        test = (BigBigIntegeriger item) => item % 19 == 0,
//        throwIfTrue = 2,
//        throwIfFalse = 0
//    },
//    new Monkey() // Monkey 2
//    {
//        items = new List<BigBigIntegeriger> { 79, 60, 97 },
//        operation = (BigBigIntegeriger item) => item * item,
//        test = (BigBigIntegeriger item) => item % 13 == 0,
//        throwIfTrue = 1,
//        throwIfFalse = 3
//    },
//    new Monkey() // Monkey 3
//    {
//        items = new List<BigBigIntegeriger> { 74 },
//        operation = (BigBigIntegeriger item) => item + 3,
//        test = (BigBigIntegeriger item) => item % 17 == 0,
//        throwIfTrue = 0,
//        throwIfFalse = 1
//    },
//};



int[] inspections = { 0,0,0,0,0,0,0,0 };

for (var i = 0; i < 10000; i++)
{
    for (var j = 0; j < monkeys.Count; j++)
    {
        for (var k = 0; k < monkeys[j].items.Count; k++)
        {
            inspections[j]++;
            monkeys[j].items[k] = monkeys[j].operation(monkeys[j].items[k]);
            if (monkeys[j].test(monkeys[j].items[k]))
            {
                monkeys[monkeys[j].throwIfTrue].items.Add(monkeys[j].items[k]);
            }
            else
            {
                monkeys[monkeys[j].throwIfFalse].items.Add(monkeys[j].items[k]);
            }
        }

        monkeys[j].items = new List<Worry>();
    }

    Console.WriteLine($"Round {i+1}");
}

foreach (var inspection in inspections)
{
    Console.WriteLine(inspection);
}

  

class Monkey
{
    public List<Worry> items;
    public Func<Worry, Worry> operation;
    public Func<Worry, bool> test;
    public int throwIfTrue;
    public int throwIfFalse;
}

class Worry
{
    public List<int> multipliers;
    public BigInteger addition;

    public void Update()
    {
        var temp = new List<int>();
        foreach (var item in multipliers)
        {
            temp.AddRange(PrimeFactors(item));
        }

        temp = temp.Distinct().ToList();
        multipliers = temp;
    }
    public Worry(int value)
    {
        multipliers = new List<int> { value };
        Update();
    }

    static List<int> PrimeFactors(int n)
    {
        List<int> primes = new List<int>();
        while (n % 2 == 0)
        {
            primes.Add(2);
            n /= 2;
        }

        for (int i = 3; i < Math.Sqrt(n); i += 2)
        {
            while (n % i == 0)
            {
                primes.Add(i);
                n /= i;
            }
        }

        if (n > 2)
            // output factors
            primes.Add(n);
        return primes;
    }
}

