using System.Collections.Immutable;

namespace aoc2022;

public class Aoc20221205 : AocBase
{
    private readonly IEnumerable<string> _stackConfigRows;
    public IEnumerable<string> StackConfigRows => _stackConfigRows.ToImmutableArray();


    private readonly IEnumerable<string> _moveRows;
    public IEnumerable<string> MoveRows => _moveRows.ToImmutableArray();


    private Stack<string>[] _stacks;
    public IReadOnlyCollection<Stack<string>> Stacks => _stacks;

    public string TopCrates
    {
        get
        {
            return _stacks.Aggregate(string.Empty, (current, stack) => current + stack.Peek()[1]);
        }
    }


    private int _separatorLineIndex;

    public int NumberOfStacks => _stackConfigRows.Last().Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;


    public Aoc20221205(string rawInput)
    {
        _stacks = Array.Empty<Stack<string>>();

        InputRows = SplitInputString(rawInput).ToArray();

        _separatorLineIndex = SeparatorLineIndex();

        _stackConfigRows = InputRows.Take(_separatorLineIndex);

        _moveRows = InputRows.Skip(_separatorLineIndex + 1);

        InitialzeStacks();

        FillStacks();

        //ExecuteMoves();

        ExecuteMultiMoves();
    }

    private void InitialzeStacks()
    {
        _stacks = new Stack<string>[NumberOfStacks];

        for (var i = 0; i < NumberOfStacks; i++)
        {
            _stacks[i] = new Stack<string>();
        }
    }

    private void FillStacks()
    {
        for (var i = _stackConfigRows.Count()-2; i >= 0; i--)
        {
            for (var j = 0; j < NumberOfStacks; j++)
            {
                var crate = new string(_stackConfigRows.ElementAt(i).Skip(j * 4).Take(3).ToArray());
                if (!string.IsNullOrWhiteSpace(crate))
                {
                    _stacks[j].Push(crate);
                }
            }
        }
    }

    private void ExecuteMoves()
    {
        foreach (var r in InputRows.Skip(_stackConfigRows.Count() + 1))
        {
            var moves = int.Parse(r.Split(" ")[1]);
            var from = int.Parse(r.Split(" ")[3]) - 1;
            var to = int.Parse(r.Split(" ")[5]) - 1;

            for (var i = 0; i < moves; i++)
            {
                var crate = _stacks[from].Pop();

                _stacks[to].Push(crate);
            }
        }
    }

    private void ExecuteMultiMoves()
    {
        var multiMoveBuffer = new Stack<string>();

        foreach (var r in InputRows.Skip(_stackConfigRows.Count() + 1))
        {
            var moves = int.Parse(r.Split(" ")[1]);
            var from = int.Parse(r.Split(" ")[3]) - 1;
            var to = int.Parse(r.Split(" ")[5]) - 1;

            for (var i = 0; i < moves; i++)
            {
                multiMoveBuffer.Push(_stacks[from].Pop());
            }

            for (var i = 0; i < moves; i++)
            {
                _stacks[to].Push(multiMoveBuffer.Pop());
            }
        }
    }

    private int SeparatorLineIndex()
    {
        for (var i = 0; i < InputRows.Count(); i++)
        {
            if (string.IsNullOrWhiteSpace(InputRows.ElementAt(i)))
            {
                return i;
            }
        }

        return -1;
    }
}