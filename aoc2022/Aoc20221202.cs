namespace aoc2022;

public class Aoc20221202
{
    private readonly Dictionary<char, Shape> _charToShapeScore = new()
    {
        {'A', Shape.Rock},
        {'B', Shape.Paper},
        {'C', Shape.Scissors},
        {'X', Shape.Rock},
        {'Y', Shape.Paper},
        {'Z', Shape.Scissors},
    };

    private readonly (char, char)[] _losingCombinations = 
    {
        ('A', 'Z'),
        ('B', 'X'),
        ('C', 'Y')
    };

    private readonly (char, char)[] _winningCombinations = 
    {
        ('A', 'Y'),
        ('B', 'Z'),
        ('C', 'X')
    };

    private readonly List<(char, char)> _rounds;
    public IReadOnlyList<(char, char)> Rounds => _rounds;

    private readonly List<int> _results;
    public IReadOnlyList<int> Results => _results;

    public Aoc20221202(string rawInput)
    {
        _rounds = new List<(char, char)>();
        _results = new List<int>();

        var rows = rawInput.Split("\r\n");

        foreach (var row in rows.Where(r => !string.IsNullOrWhiteSpace(r)))
        {
            _rounds.Add((row.First(), row.Last()));
        }
    }

    public void CalculateResultsByShape()
    {
        const int loseValue = 0;
        const int drawValue = 3;
        const int winValue = 6;

        foreach (var r in _rounds)
        {
            var resultValue = drawValue;

            if (_winningCombinations.Contains(r))
            {
                resultValue = winValue;
            } 
            else if (_losingCombinations.Contains(r))
            {
                resultValue = loseValue;
            }

            _results.Add(resultValue + (int)_charToShapeScore[r.Item2]);
        }
    }

    public void CalculateResultsByOutcome()
    {
        for (int i = 0; i < _rounds.Count; i++)
        {
            if (_rounds[i].Item2 == 'Z')
            {
                _rounds[i] = _winningCombinations.Single(lc => lc.Item1 == _rounds[i].Item1);
                    
            }
            else if (_rounds[i].Item2 == 'X')
            {
                _rounds[i] = _losingCombinations.Single(lc => lc.Item1 == _rounds[i].Item1);
            }
            else
            {
                _rounds[i] = (_rounds[i].Item1, _rounds[i].Item1);
            }
        }

        CalculateResultsByShape();
    }
}

public enum Shape
{
    Rock = 1,
    Paper = 2,
    Scissors = 3
}