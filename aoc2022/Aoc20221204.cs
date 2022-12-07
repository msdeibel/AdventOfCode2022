using System.Collections.Immutable;

namespace aoc2022.Test;

public class Aoc20221204 : AocBase
{
    private readonly IList<SectionSet> _sections;
    public IImmutableList<SectionSet> Sections => _sections.ToImmutableList();

    public Aoc20221204(string rawInput)
        : base(rawInput)
    {
        _sections = new List<SectionSet>(InputRows.Count());

        foreach (var inputRow in InputRows)
        {
            _sections.Add(new SectionSet(inputRow));
        }
    }
}

public class SectionSet
{
    private readonly int[] _sectionLimits;

    public bool HasFullOverlap
    {
        get
        {

            var sections = SectionRanges();
            var intersection = sections.s1.Intersect(sections.s2);

            return intersection.Count() == sections.s1.Length
                   || intersection.Count() == sections.s2.Length;
        }
    }

    public bool HasPartialOverlap
    {
        get
        {
            var sections = SectionRanges();

            return sections.s1.Intersect(sections.s2).Any();
        }
    }

    public SectionSet(string sectionRow)
    {
        _sectionLimits = sectionRow.Split(new char[]{',', '-'}).Select(int.Parse).ToArray();
    }

    private (int[] s1, int[] s2) SectionRanges()
    {
        var s1Start = _sectionLimits[0];
        var s1End = _sectionLimits[1];
        var s2Start = _sectionLimits[2];
        var s2End = _sectionLimits[3];

        var s1 = Enumerable.Range(s1Start, s1End - s1Start + 1).ToArray();
        var s2 = Enumerable.Range(s2Start, s2End - s2Start + 1).ToArray();

        return (s1, s2);
    }
}