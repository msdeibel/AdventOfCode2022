using System.Collections.Immutable;

namespace aoc2022;

public class Aoc20221209 : AocBase
{
    public IList<Move> Moves { get; }

    public IList<string> PositionsAfterMoves { get; }

    public Knot Head { get; private set; }

    public Knot Tail { get; private set; }


    public Aoc20221209(string rawInput)
        : base(rawInput)
    {
        Head = new Knot(null);
        Tail = new Knot(Head);

        Moves = new List<Move>(InputRows.Count());
        PositionsAfterMoves = new List<string>();

        foreach (var row in InputRows)
        {
            Moves.Add(new Move(row));
        }

        foreach (var move in Moves)
        {
            Head.MoveIt(move);
        }
    }
}

public class Move
{
    public char Direction { get; }

    public int Steps { get; }

    public Move(string moveRow)
    {
        Direction = moveRow[0];

        Steps = moveRow[2] - 48;
    }
}

public delegate void PositionChanged((int, int) oldPosition, (int, int) newPosition);

public class Knot
{
    private readonly IList<(int, int)> _visitedPositions;

    public IReadOnlyList<(int, int)> VisitedPositions => _visitedPositions.ToImmutableList();  

    private readonly (int Row, int Column) _startingPosition = (0, 0);
    
    //public int VisitedPositions => _visitedPositions.Count;

    public (int row, int column) Position { get; private set; }

    public event PositionChanged? PositionChanged;

    public Knot()
    {
        _visitedPositions = new List<(int, int)>();
        Position = (_startingPosition.Row, _startingPosition.Column);

        OnPositionChanged(Position);
}

    public Knot(Knot? leadingKnot)
    {
        _visitedPositions = new List<(int, int)>();
        Position = (_startingPosition.Row, _startingPosition.Column);

        if (leadingKnot != null)
        {
            leadingKnot.PositionChanged += LeadingKnotPositionChanged;
        }

        OnPositionChanged(Position);
    }

    private void MoveOneInDirection(char direction)
    {
        var oldPosition = (Position.row, Position.column);

        Position = direction switch
        {
            'R' => (Position.row, Position.column + 1),
            'L' => (Position.row, Position.column - 1),
            'U' => (Position.row + 1, Position.column),
            'D' => (Position.row - 1, Position.column),
            _ => Position
        };

        OnPositionChanged(oldPosition);
    }

    private void SaveCurrentPosition()
    {
        if (!_visitedPositions.Contains((Position.row, Position.column)))
        {
            _visitedPositions.Add((Position.row, Position.column));
        }
    }

    public void MoveIt(Move move)
    {
        for (var i = 0; i < move.Steps; i++)
        {
            MoveOneInDirection(move.Direction);
        }
    }

    private (int row, int column) PositionalDifferenceTo((int row, int column) otherPosition)
    {
        return (Position.row - otherPosition.row,
            Position.column - otherPosition.column);
    }

    private void OnPositionChanged((int, int) oldPosition)
    {
        SaveCurrentPosition();

        PositionChanged?.Invoke(oldPosition, Position);
    }

    private void LeadingKnotPositionChanged((int row, int column) oldLeadingPosition, (int row, int column) newLeadingPosition)
    {
        var previousPosition = (Position.row, Position.column);

        var diff = PositionalDifferenceTo(newLeadingPosition);

        var diagonalMoveRequired = Math.Abs(diff.row) > 1 && Math.Abs(diff.column) == 1
                                   || Math.Abs(diff.row) == 1 && Math.Abs(diff.column) > 1;

        if (diagonalMoveRequired)
        {
            Position = (oldLeadingPosition.row, oldLeadingPosition.column);
        }
        else
        {
            if (Math.Abs(diff.row) > 1)
            {
                Position = (Position.row - Math.Sign(diff.row), Position.column);
            }

            if (Math.Abs(diff.column) > 1)
            {
                Position = (Position.row, Position.column - Math.Sign(diff.column));
            }
        }

        OnPositionChanged(previousPosition);
    }

    public override bool Equals(object obj)
    {
        return obj is Knot otherKnot
               && Position.row == otherKnot.Position.row
               && Position.column == otherKnot.Position.column;
    }
}


