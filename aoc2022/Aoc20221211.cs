using System.Collections.Immutable;
using System.Diagnostics;

namespace aoc2022;

public class Aoc20221211 : AocBase
{
    public IList<Monkey> Monkeys { get; private set; }

    public Aoc20221211(string rawInput, int rounds)
        : base(rawInput)
    {
        var monkeyCount = InputRows.Count(i => i.StartsWith("Monkey"));

        Monkeys = new List<Monkey>(monkeyCount);

        for (var i = 0; i < monkeyCount; i++)
        {
            var monkeyDescription = InputRows.Skip(i * 7).Take(6).ToArray();

            Monkeys.Add(new Monkey(monkeyDescription));
        }

        foreach (var monkey in Monkeys)
        {
            monkey.SetTrueTargetHandler(Monkeys[monkey.TrueTarget]);
            monkey.SetFalseTargetHandler(Monkeys[monkey.FalseTarget]);
        }

        for (int i = 0; i < rounds; i++)
        {
            foreach (var monkey in Monkeys)
            {
                monkey.ExecuteTurn();
            }
        }
    }
}

public delegate void Tested(int worryLevel);

public class Monkey
{
    public int InspectionCount;
    private Queue<int> _items;
    public IReadOnlyList<int> Items => _items.ToImmutableList();

    private string[] _monkeyDescription;

    public MonkeyOperation Operation { get; private set; }

    public int Divider { get; private set; }

    public int TrueTarget => _monkeyDescription[4].Last() - 48;

    public int FalseTarget => _monkeyDescription[5].Last() - 48;

    public event Tested TestedFalse;
    public event Tested TestedTrue;


    public string MonkeyId => _monkeyDescription[0].TrimEnd(':');

    public Monkey(string[] monkeyDescription)
    {
        _monkeyDescription = monkeyDescription;
        InspectionCount = 0;

        InitItems();
        InitOperation();
        InitDivider();
    }

    private void InitItems()
    {
        _items = new Queue<int>();
        var initialItems = _monkeyDescription[1]
            .Split(':')[1]
            .Replace(" ", string.Empty)
            .Split(',')
            .Select(int.Parse);

        foreach (var initialItem in initialItems)
        {
            _items.Enqueue(initialItem);
        }
    }

    private void InitOperation()
    {
        Operation = new MonkeyOperation(_monkeyDescription[2]);
    }

    private void InitDivider()
    {
        Divider = int.Parse(_monkeyDescription[3].Split(' ', StringSplitOptions.RemoveEmptyEntries)[3]);
    }

    public int NextItem()
    {
        return _items.Dequeue();
    }

    public void Inspect()
    {
        var itemValue = NextItem();

        var newItemValue = CalculateneWorryLevel(itemValue) % 29_099_070;

        if (newItemValue % Divider == 0)
        {
            OnTestedTrue(newItemValue);
        }
        else
        {
            OnTestedFalse(newItemValue);
        }

        InspectionCount++;
    }

    public void ExecuteTurn()
    {
        while (_items.Any())
        {
            Inspect();
        }
    }

    private int CalculateneWorryLevel(int itemValue)
    {
        int operationValue = 1;

        operationValue = Operation.Value.Equals("old") 
            ? itemValue 
            : int.Parse(Operation.Value);

        return Operation.Operator switch
        {
            '+' => itemValue + operationValue,
            _ => itemValue * operationValue
        };
    }

    public void OnTestedFalse(int worryLevel)
    {
        TestedFalse?.Invoke(worryLevel);
    }

    public void OnTestedTrue(int worryLevel)
    {
        TestedTrue?.Invoke(worryLevel);
    }

    public void HandleItemThrow(int item)
    {
        _items.Enqueue(item);
    }

    public void SetFalseTargetHandler(Monkey falseTarget)
    {
        TestedFalse += falseTarget.HandleItemThrow;
    }

    public void SetTrueTargetHandler(Monkey trueTarget)
    {
        TestedTrue += trueTarget.HandleItemThrow;
    }
}

public class MonkeyOperation
{
    public MonkeyOperation(string operationDescription)
    {
        Operator = operationDescription.Split(' ', StringSplitOptions.RemoveEmptyEntries)[4][0];
        Value = operationDescription.Split(' ', StringSplitOptions.RemoveEmptyEntries)[5];
    }

    public char Operator { get; private set; }

    public string Value { get; private set; }
}
