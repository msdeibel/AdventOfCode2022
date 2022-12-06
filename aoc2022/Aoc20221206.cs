namespace aoc2022;

public class Aoc20221206 : AocBase
{
    private const int PacketMarkerLength = 4;
    private const int MessageMarkerLength = 14;

    public int PacketMarkerValue => GetMarkerValue(PacketMarkerLength);

    public int MessageMarkerValue => GetMarkerValue(MessageMarkerLength);

    public Aoc20221206(string rawInput)
    {
        InputRows = SplitInputString(rawInput);
    }

    private int GetMarkerValue(int markerLength)
    {
        var input = InputRows.ElementAt(0);

        for (var i = markerLength; i < input.Length - 1; i++)
        {
            var markerSet = input.Skip(i - markerLength).Take(markerLength);

            if (markerSet.Count() == markerSet.Distinct().Count())
            {
                return i;
            }
        }

        return 0;
    }

}