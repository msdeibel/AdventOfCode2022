using Xunit.Abstractions;

namespace aoc2022.Test;

public class Aoc20221215Tests
{
    private readonly ITestOutputHelper output;

    public Aoc20221215Tests(ITestOutputHelper output)
    {
        this.output = output;
    }


    [Fact]
    public void ExampleItemsDetected()
    {
        var aoc20221209 = new Aoc20221215(Example1Input());

        Assert.Equal(28, aoc20221209.MapPoints.Count);

        Assert.True(aoc20221209.MapPoints[0].IsSensor);
        Assert.False(aoc20221209.MapPoints[0].IsBeacon);
        Assert.Equal(2, aoc20221209.MapPoints[0].X);
        Assert.Equal(18, aoc20221209.MapPoints[0].Y);

        Assert.False(aoc20221209.MapPoints[1].IsSensor);
        Assert.True(aoc20221209.MapPoints[1].IsBeacon);
        Assert.Equal(-2, aoc20221209.MapPoints[1].X);
        Assert.Equal(15, aoc20221209.MapPoints[1].Y);
    }

    [Fact]
    public void DistanceForSensor1Is7()
    {
        var aoc20221209 = new Aoc20221215(Example1Input());

        var md = aoc20221209.MapPoints[0].ManhattanDistanceTo(aoc20221209.MapPoints[1]);

        Assert.Equal(7, md);
    }

    [Fact]
    public void DistanceForSensor2Is1()
    {
        var aoc20221209 = new Aoc20221215(Example1Input());

        var md = aoc20221209.MapPoints[2].ManhattanDistanceTo(aoc20221209.MapPoints[3]);

        Assert.Equal(1, md);
    }


    [Fact]
    public void ExampleColumnCount()
    {
        var aoc20221209 = new Aoc20221215(Example1Input());

        Assert.Equal(37, aoc20221209.Columns);
    }

    [Fact]
    public void ExampleRowCount()
    {
        var aoc20221209 = new Aoc20221215(Example1Input());

        Assert.Equal(37, aoc20221209.Rows);
    }

    //[Fact]
    //public void ExampleMapFilledWithDots()
    //{
    //    var aoc20221209 = new Aoc20221215(Example1Input());

    //    Assert.Equal('.', aoc20221209.Map[0, 0]);
    //    Assert.Equal('.', aoc20221209.Map[0, 27]);
    //    Assert.Equal('.', aoc20221209.Map[22, 0]);
    //    Assert.Equal('.', aoc20221209.Map[22, 27]);
    //}

    //[Fact]
    //public void ExampleMapFilledSensorsAndBeacon()
    //{
    //    var aoc20221209 = new Aoc20221215(Example1Input());

    //    for (int i = 0; i < aoc20221209.Rows; i++)
    //    {
    //        var line = string.Empty;

    //        for (int j = 0; j < aoc20221209.Columns; j++)
    //        {
    //            line += aoc20221209.Map[i, j];
    //        }

    //        output.WriteLine(line);
    //    }

    //    Assert.Equal('S', aoc20221209.Map[0, 4]);
    //    Assert.Equal('S', aoc20221209.Map[11, 2]);
    //    Assert.Equal('B', aoc20221209.Map[15, 0]);
    //    Assert.Equal('B', aoc20221209.Map[17, 27]);
    //    Assert.Equal('B', aoc20221209.Map[22, 23]);
    //}

    [Fact]
    public void ExampleMapFilledSensorsAndBeacon()
    {
        var aoc20221209 = new Aoc20221215(Example1Input());

        for (int i = 0; i < aoc20221209.Rows; i++)
        {
            var line = string.Empty;

            for (int j = 0; j < aoc20221209.Columns; j++)
            {
                line += aoc20221209.Map[i, j];
            }

            output.WriteLine(line);
        }

        Assert.Equal('S', aoc20221209.Map[10, 10]);
        Assert.Equal('S', aoc20221209.Map[21, 8]);
        Assert.Equal('B', aoc20221209.Map[25, 6]);
        Assert.Equal('B', aoc20221209.Map[27, 33]);
        Assert.Equal('B', aoc20221209.Map[32, 29]);
    }

    [Fact]
    public void ExampleMapFilledMarkers()
    {
        var aoc20221209 = new Aoc20221215(Example1Input());

        var x = aoc20221209.MapPoints.Where(p => p.Y == 10 - aoc20221209._minY && (p.IsExcluded));

        output.WriteLine(new string(x.Where(y => y.IsExcluded).Select(z => '#').ToString()));

        for (int i = 0; i < aoc20221209.Rows; i++)
        {
            var line = (i + aoc20221209._minY).ToString().PadLeft(3, ' ') + " | " + (i).ToString().PadLeft(3, ' ');

            for (int j = 0; j < aoc20221209.Columns; j++)
            {
                line +=  aoc20221209.Map[i, j];
            }

            output.WriteLine(line);
        }

        Assert.Equal(26, x.Count());
    }

    [Fact]
    public void PuzzlePart1MapFilledMarkers()
    {
        var aoc20221209 = new Aoc20221215(PuzzleInput());

        var x = aoc20221209.MapPoints.Where(p => p.Y == 2_000_000);

        //for (int i = 0; i < aoc20221209.Rows; i++)
        //{
        //    var line = string.Empty;

        //    for (int j = 0; j < aoc20221209.Columns; j++)
        //    {
        //        line += aoc20221209.Map[i, j];
        //    }

        //    output.WriteLine(line);
        //}

        //Assert.Equal('S', aoc20221209.Map[10, 10]);
        //Assert.Equal('S', aoc20221209.Map[21, 8]);
        //Assert.Equal('B', aoc20221209.Map[25, 6]);
        //Assert.Equal('B', aoc20221209.Map[27, 33]);
        //Assert.Equal('B', aoc20221209.Map[32, 29]);
    }


    private string Example1Input()
    {
        return @"Sensor at x=2, y=18: closest beacon is at x=-2, y=15
Sensor at x=9, y=16: closest beacon is at x=10, y=16
Sensor at x=13, y=2: closest beacon is at x=15, y=3
Sensor at x=12, y=14: closest beacon is at x=10, y=16
Sensor at x=10, y=20: closest beacon is at x=10, y=16
Sensor at x=14, y=17: closest beacon is at x=10, y=16
Sensor at x=8, y=7: closest beacon is at x=2, y=10
Sensor at x=2, y=0: closest beacon is at x=2, y=10
Sensor at x=0, y=11: closest beacon is at x=2, y=10
Sensor at x=20, y=14: closest beacon is at x=25, y=17
Sensor at x=17, y=20: closest beacon is at x=21, y=22
Sensor at x=16, y=7: closest beacon is at x=15, y=3
Sensor at x=14, y=3: closest beacon is at x=15, y=3
Sensor at x=20, y=1: closest beacon is at x=15, y=3";
    }

    private string PuzzleInput()
    {
        return @"Sensor at x=3907621, y=2895218: closest beacon is at x=3790542, y=2949630
Sensor at x=1701067, y=3075142: closest beacon is at x=2275951, y=3717327
Sensor at x=3532369, y=884718: closest beacon is at x=2733699, y=2000000
Sensor at x=2362427, y=41763: closest beacon is at x=2999439, y=-958188
Sensor at x=398408, y=3688691: closest beacon is at x=2275951, y=3717327
Sensor at x=1727615, y=1744968: closest beacon is at x=2733699, y=2000000
Sensor at x=2778183, y=3611924: closest beacon is at x=2275951, y=3717327
Sensor at x=2452818, y=2533012: closest beacon is at x=2733699, y=2000000
Sensor at x=88162, y=2057063: closest beacon is at x=-109096, y=390805
Sensor at x=2985370, y=2315046: closest beacon is at x=2733699, y=2000000
Sensor at x=2758780, y=3000106: closest beacon is at x=3279264, y=2775610
Sensor at x=3501114, y=3193710: closest beacon is at x=3790542, y=2949630
Sensor at x=313171, y=1016326: closest beacon is at x=-109096, y=390805
Sensor at x=3997998, y=3576392: closest beacon is at x=3691556, y=3980872
Sensor at x=84142, y=102550: closest beacon is at x=-109096, y=390805
Sensor at x=3768533, y=3985372: closest beacon is at x=3691556, y=3980872
Sensor at x=2999744, y=3998031: closest beacon is at x=3691556, y=3980872
Sensor at x=3380504, y=2720962: closest beacon is at x=3279264, y=2775610
Sensor at x=3357940, y=3730208: closest beacon is at x=3691556, y=3980872
Sensor at x=1242851, y=838744: closest beacon is at x=-109096, y=390805
Sensor at x=3991401, y=2367688: closest beacon is at x=3790542, y=2949630
Sensor at x=3292286, y=2624894: closest beacon is at x=3279264, y=2775610
Sensor at x=2194423, y=3990859: closest beacon is at x=2275951, y=3717327";
    }
}