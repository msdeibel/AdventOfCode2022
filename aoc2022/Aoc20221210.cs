namespace aoc2022;

public class Aoc20221210 : AocBase
{
    public int RegisterX { get; }

    private readonly Dictionary<int, int> _cycle2RegisterValue;

    public IReadOnlyDictionary<int, int> Cycle2RegisterValue => _cycle2RegisterValue;

    public Aoc20221210(string rawInput)
        : base(rawInput)
    {
        _cycle2RegisterValue = new Dictionary<int, int>();
        RegisterX = 1;

        var q = new Queue<Operation>();
        //q.Enqueue(new Operation("noop"));

        var cycle = 0;
        var isAdding = false;
        Operation op = null;

        int instructionPointer = 0;

        do
        {
            cycle++;

            _cycle2RegisterValue[cycle] = RegisterX * cycle;

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
                RegisterX += op.Value;
                isAdding = false;
            }
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
