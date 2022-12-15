using System.Collections.Immutable;

namespace aoc2022;

public class Aoc20221210 : AocBase
{
    public int RegisterX { get; }

    private IList<char> _crt { get; }
    public IReadOnlyList<char> CRT => _crt.ToImmutableList();

    private readonly Dictionary<int, int> _cycle2RegisterValue;
    public IReadOnlyDictionary<int, int> Cycle2RegisterValue => _cycle2RegisterValue;

    public Aoc20221210(string rawInput)
        : base(rawInput)
    {
        _cycle2RegisterValue = new Dictionary<int, int>();
        _crt = new List<char>();
        RegisterX = 1;

        Operation op = null;

        var cycle = 0;
        var isAdding = false;
        var instructionPointer = 0;
        var spritePosition = 1;

        do
        {
            cycle++;

            _cycle2RegisterValue[cycle] = RegisterX * cycle;

            var spriteRange = Enumerable.Range(spritePosition-1, 3);

            _crt.Add(spriteRange.Contains((cycle - 1) % 40)
                ? '#'
                : '.');

            if (!isAdding)
            {
                // Start operation
                op = new Operation(InputRows.ElementAt(instructionPointer));

                if (op.IsAdd)
                {
                    isAdding = true;
                }

                instructionPointer++;
            }
            else
            {
                // Complete addx Op
                RegisterX += op.Value;
                isAdding = false;
            }

            spritePosition = RegisterX;

        } while (instructionPointer < InputRows.Count());
    }
}

public class Operation
{
    public string Command { get; private set; }

    public int Value { get; private set; }

    public bool IsAdd => Command.Equals("addx");

    public Operation(string rawInput)
    {
        Command = rawInput.Split(' ')[0];

        if (Command.Equals("addx"))
        {
            Value = int.Parse(rawInput.Split(' ')[1]);
        }
    }
}
