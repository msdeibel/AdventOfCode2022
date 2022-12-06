namespace aoc2022;

public class Aoc20221203 : AocBase
{
    private string _rawInput;

    private List<(string, string)> _splitRows;
    public IReadOnlyList<(string, string)> SplitRows => _splitRows;

    private List<char> _duplicates;
    public IReadOnlyList<char> Duplicates => _duplicates;

    private List<char> _badges;

    public Aoc20221203(string rawInput)
    {
        _splitRows = new List<(string, string)>();
        _badges = new List<char>();

        _rawInput = rawInput;

        SplitInputRows(rawInput);

        _duplicates = new List<char>(_splitRows.Count);


        FindDuplicates();
    }

    private void FindDuplicates()
    {
        foreach (var r in _splitRows)
        {
            _duplicates.Add(r.Item1.ToCharArray().Intersect(r.Item2.ToCharArray()).First());
        }
    }

    private void SplitInputRows(string rawInput)
    {
        var rows = SplitInputString(rawInput);

        foreach (var r in rows)
        {
            var middle = r.Length / 2;

            _splitRows.Add((new string(r.ToCharArray().Take(middle).ToArray()), 
                new string(r.ToCharArray().Skip(middle).Take(middle).ToArray())));
        }
    }

    public int PrioritiesSum(IEnumerable<char> items)
    {
        var sum = 0;

        foreach (var i in items)
        {
            if (char.IsLower(i))
            {
                sum += (i - 96);
            }
            else
            {
                sum += (i - 38);
            }
        }

        return sum;
    }

    public int FindBadgesSum()
    {
        var startingPosition = 0;

        var rows = SplitInputString(_rawInput);

        while (startingPosition < rows.Count())
        {
            var relevantRows = rows.Skip(startingPosition).Take(3).ToArray();

            var badgeType = relevantRows.ElementAt(0).Intersect(relevantRows.ElementAt(1).Intersect(relevantRows.ElementAt(2))).First();

            _badges.Add(badgeType);

            startingPosition += 3;
        }

        return PrioritiesSum(_badges);
    }
}