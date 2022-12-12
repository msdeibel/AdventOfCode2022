using Microsoft.VisualStudio.TestPlatform.Utilities;

using Xunit.Abstractions;

namespace aoc2022.Test;

public class Aoc20221210Tests
{
    private readonly ITestOutputHelper output;

    public Aoc20221210Tests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public void ExampleItemsDetected()
    {
        var aoc20221210 = new Aoc20221210(Example1Input());

        Assert.Equal(420, aoc20221210.Cycle2RegisterValue[20]);
    }

    [Fact]
    public void ShortExampleItemsDetected()
    {
        var aoc20221210 = new Aoc20221210(@"noop
addx 3
addx -5");

        Assert.Equal(1, aoc20221210.Cycle2RegisterValue[1]);
        Assert.Equal(2, aoc20221210.Cycle2RegisterValue[2]);
        Assert.Equal(3, aoc20221210.Cycle2RegisterValue[3]);
        Assert.Equal(16, aoc20221210.Cycle2RegisterValue[4]);
       // Assert.Equal(1, aoc20221210.Cycle2RegisterValue[5]);
    }

    [Fact]
    public void AllSignalsInExample()
    {
        var aoc20221210 = new Aoc20221210(Example1Input());

        int total = 0;

        for (int i = 20; i < aoc20221210.Cycle2RegisterValue.Count; i += 40)
        {
            total += aoc20221210.Cycle2RegisterValue[i];
        }

        Assert.Equal(13140, total);
    }


    [Fact]
    public void Part1PuzzleInput()
    {
        var aoc20221210 = new Aoc20221210(PuzzleInput());

        int total = 0;

        for (int i = 20; i < aoc20221210.Cycle2RegisterValue.Count; i += 40)
        {
            total += aoc20221210.Cycle2RegisterValue[i];
        }

        Assert.Equal(14760, total);
    }

    [Fact]
    public void FiveCyclesWithCrt()
    {
        var aoc20221210 = new Aoc20221210(Example1Input());

        Assert.Equal(new List<char>(){'#','#', '.','.', '#', '#', '.', '.', '#', '#', '.', '.', '#', '#', '.', '.', '#', '#', '.', '.', '#', '#', '.', '.', '#', '#', '.', '.', '#', '#', '.', '.', '#', '#', '.', '.', '#', '#', '.', '.' }
            , aoc20221210.CRT.Take(40));
    }

    [Fact]
    public void Part2WithCrt()
    {
        var aoc20221210 = new Aoc20221210(PuzzleInput());

        var crtRows = new List<string>();

        int r = 0;

        var rowContent = string.Empty;

        do
        {
            rowContent = new string(aoc20221210.CRT.Skip(r * 40).Take(40).ToArray());

            if(!string.IsNullOrEmpty(rowContent))
                crtRows.Add(rowContent);

            r++;

        } while (!string.IsNullOrEmpty(rowContent));

        foreach (var item in crtRows)
        {
            output.WriteLine(item);
        }
        
    }

    private static string Example1Input()
    {
        return @"addx 15
addx -11
addx 6
addx -3
addx 5
addx -1
addx -8
addx 13
addx 4
noop
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx 5
addx -1
addx -35
addx 1
addx 24
addx -19
addx 1
addx 16
addx -11
noop
noop
addx 21
addx -15
noop
noop
addx -3
addx 9
addx 1
addx -3
addx 8
addx 1
addx 5
noop
noop
noop
noop
noop
addx -36
noop
addx 1
addx 7
noop
noop
noop
addx 2
addx 6
noop
noop
noop
noop
noop
addx 1
noop
noop
addx 7
addx 1
noop
addx -13
addx 13
addx 7
noop
addx 1
addx -33
noop
noop
noop
addx 2
noop
noop
noop
addx 8
noop
addx -1
addx 2
addx 1
noop
addx 17
addx -9
addx 1
addx 1
addx -3
addx 11
noop
noop
addx 1
noop
addx 1
noop
noop
addx -13
addx -19
addx 1
addx 3
addx 26
addx -30
addx 12
addx -1
addx 3
addx 1
noop
noop
noop
addx -9
addx 18
addx 1
addx 2
noop
noop
addx 9
noop
noop
noop
addx -1
addx 2
addx -37
addx 1
addx 3
noop
addx 15
addx -21
addx 22
addx -6
addx 1
noop
addx 2
addx 1
noop
addx -10
noop
noop
addx 20
addx 1
addx 2
addx 2
addx -6
addx -11
noop
noop
noop";
    }

    private string PuzzleInput()
    {
        return @"addx 2
addx 3
noop
noop
addx 1
addx 5
addx -1
addx 5
addx 1
noop
noop
addx 4
noop
noop
addx 5
addx -5
addx 6
addx 3
addx 1
addx 5
addx 1
noop
addx -38
addx 41
addx -22
addx -14
addx 7
noop
noop
addx 3
addx -2
addx 2
noop
addx 17
addx -12
addx 5
addx 2
addx -16
addx 17
addx 2
addx 5
addx 2
addx -30
noop
addx -6
addx 1
noop
addx 5
noop
noop
noop
addx 5
addx -12
addx 17
noop
noop
noop
noop
addx 5
addx 10
addx -9
addx 2
addx 5
addx 2
addx -5
addx 6
addx 4
noop
noop
addx -37
noop
noop
addx 17
addx -12
addx 30
addx -23
addx 2
noop
addx 3
addx -17
addx 22
noop
noop
noop
addx 5
noop
addx -10
addx 11
addx 4
noop
addx 5
addx -2
noop
addx -6
addx -29
addx 37
addx -30
addx 27
addx -2
addx -22
noop
addx 3
addx 2
noop
addx 7
addx -2
addx 2
addx 5
addx -5
addx 6
addx 2
addx 2
addx 5
addx -25
noop
addx -10
noop
addx 1
noop
addx 2
noop
noop
noop
noop
addx 7
addx 1
addx 4
addx 1
noop
addx 2
noop
addx 3
addx 5
addx -1
noop
addx 3
addx 5
addx 2
addx 1
noop
noop
noop
noop";
    }
}