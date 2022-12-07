namespace aoc2022;

public class AocBase
{
    public IEnumerable<string>? InputRows { get; protected set; }

    protected AocBase(string rawInput)
    {
        InputRows = SplitInputString(rawInput);
    }

    protected IEnumerable<string> SplitInputString(string rawInput)
    {
        return rawInput.Split("\r\n");
    }
}