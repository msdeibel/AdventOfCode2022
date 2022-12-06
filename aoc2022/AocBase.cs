namespace aoc2022;

public class AocBase
{
    public IEnumerable<string>? InputRows { get; protected set; }
    
    protected IEnumerable<string> SplitInputString(string rawInput)
    {
        return rawInput.Split("\r\n");
    }
}