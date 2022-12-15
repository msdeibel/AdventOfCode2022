namespace aoc2022.Test;

public class Aoc20221211Tests
{
    #region Part 1

    [Fact]
    public void MonkeysRegisteredWithCorrectId()
    {
        var aoc20221211 = new Aoc20221211(Example1Input(), 0);

        Assert.Equal("Monkey 0", aoc20221211.Monkeys[0].MonkeyId);
        Assert.Equal("Monkey 3", aoc20221211.Monkeys[3].MonkeyId);

    }

    [Fact]
    public void Monkey0Has2InitialItems()
    {
        var aoc20221211 = new Aoc20221211(Example1Input(), 0);

        //Assert.Equal(79, aoc20221211.Monkeys[0].NextItem());
        //Assert.Equal(98, aoc20221211.Monkeys[0].NextItem());
    }

    [Fact]
    public void MonkeyOperationIsAnalyzed()
    {
        var aoc20221211 = new Aoc20221211(Example1Input(), 0);

        Assert.Equal('*', aoc20221211.Monkeys[0].Operation.Operator);
        Assert.Equal("19", aoc20221211.Monkeys[0].Operation.Value);

        Assert.Equal('*', aoc20221211.Monkeys[2].Operation.Operator);
        Assert.Equal("old", aoc20221211.Monkeys[2].Operation.Value);
    }

    [Fact]
    public void MonkeyOperationDivider()
    {
        var aoc20221211 = new Aoc20221211(Example1Input(), 0);

        //Assert.Equal(23, aoc20221211.Monkeys[0].Divider);
        //Assert.Equal(13, aoc20221211.Monkeys[2].Divider);
    }

    [Fact]
    public void TrueFalseReceivers()
    {
        var aoc20221211 = new Aoc20221211(Example1Input(), 0);

        Assert.Equal(2, aoc20221211.Monkeys[0].TrueTarget);
        Assert.Equal(3, aoc20221211.Monkeys[0].FalseTarget);

        Assert.Equal(0, aoc20221211.Monkeys[3].TrueTarget);
        Assert.Equal(1, aoc20221211.Monkeys[3].FalseTarget);
    }


    //[Fact]
    //public void MonkeyItemsAfterExampleRound1()
    //{
    //    var aoc20221211 = new Aoc20221211(Example1Input(), 1);

    //    Assert.Equal(new List<long>{ 20, 23, 27, 26 }, aoc20221211.Monkeys[0].Items);
    //}


    [Fact]
    public void InspectionCountAfter20ExampleRounds()
    {
        var aoc20221211 = new Aoc20221211(Example1Input(), 20);

        Assert.Equal(101, aoc20221211.Monkeys[0].InspectionCount);
        Assert.Equal(95, aoc20221211.Monkeys[1].InspectionCount);
        Assert.Equal(7, aoc20221211.Monkeys[2].InspectionCount);
        Assert.Equal(105, aoc20221211.Monkeys[3].InspectionCount);
    }

    //[Fact]
    //public void InspectionCountAfter20PuzzleRounds()
    //{
    //    var aoc20221211 = new Aoc20221211(PuzzleInput(), 20);

    //    var monkeyBusiness = aoc20221211.Monkeys
    //        .OrderByDescending(m => m.InspectionCount)
    //        .Take(2)
    //        .Select(m => m.InspectionCount)
    //        .Aggregate(1, (long x, long y) => x * y);

    //    Assert.Equal(61005, monkeyBusiness);
    //}

    #endregion

    #region Part 2

    [Fact]
    public void InspectionCountAfter1ExampleRound()
    {
        var aoc20221211 = new Aoc20221211(Example1Input(), 1);

        Assert.Equal(2, aoc20221211.Monkeys[0].InspectionCount);
        Assert.Equal(4, aoc20221211.Monkeys[1].InspectionCount);
        Assert.Equal(3, aoc20221211.Monkeys[2].InspectionCount);
        Assert.Equal(6, aoc20221211.Monkeys[3].InspectionCount);
    }

    [Fact]
    public void InspectionCountAfter20ExampleRoundsPart2()
    {
        var aoc20221211 = new Aoc20221211(Example1Input(), 20);

        Assert.Equal(99, aoc20221211.Monkeys[0].InspectionCount);
        Assert.Equal(97, aoc20221211.Monkeys[1].InspectionCount);
        Assert.Equal(8, aoc20221211.Monkeys[2].InspectionCount);
        Assert.Equal(103, aoc20221211.Monkeys[3].InspectionCount);
    }

    [Fact]
    public void InspectionCountAfter1000ExampleRounds()
    {
        var aoc20221211 = new Aoc20221211(Example1Input(), 1000);

        Assert.Equal(5204, aoc20221211.Monkeys[0].InspectionCount);
        Assert.Equal(4792, aoc20221211.Monkeys[1].InspectionCount);
        Assert.Equal(199, aoc20221211.Monkeys[2].InspectionCount);
        Assert.Equal(5192, aoc20221211.Monkeys[3].InspectionCount);
    }

    #endregion

    private string Example1Input()
    {
        return @"Monkey 0:
  Starting items: 79, 98
  Operation: new = old * 19
  Test: divisible by 23
    If true: throw to monkey 2
    If false: throw to monkey 3

Monkey 1:
  Starting items: 54, 65, 75, 74
  Operation: new = old + 6
  Test: divisible by 19
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 79, 60, 97
  Operation: new = old * old
  Test: divisible by 13
    If true: throw to monkey 1
    If false: throw to monkey 3

Monkey 3:
  Starting items: 74
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 0
    If false: throw to monkey 1";
    }

    private string PuzzleInput()
    {
        return @"Monkey 0:
  Starting items: 59, 74, 65, 86
  Operation: new = old * 19
  Test: divisible by 7
    If true: throw to monkey 6
    If false: throw to monkey 2

Monkey 1:
  Starting items: 62, 84, 72, 91, 68, 78, 51
  Operation: new = old + 1
  Test: divisible by 2
    If true: throw to monkey 2
    If false: throw to monkey 0

Monkey 2:
  Starting items: 78, 84, 96
  Operation: new = old + 8
  Test: divisible by 19
    If true: throw to monkey 6
    If false: throw to monkey 5

Monkey 3:
  Starting items: 97, 86
  Operation: new = old * old
  Test: divisible by 3
    If true: throw to monkey 1
    If false: throw to monkey 0

Monkey 4:
  Starting items: 50
  Operation: new = old + 6
  Test: divisible by 13
    If true: throw to monkey 3
    If false: throw to monkey 1

Monkey 5:
  Starting items: 73, 65, 69, 65, 51
  Operation: new = old * 17
  Test: divisible by 11
    If true: throw to monkey 4
    If false: throw to monkey 7

Monkey 6:
  Starting items: 69, 82, 97, 93, 82, 84, 58, 63
  Operation: new = old + 5
  Test: divisible by 5
    If true: throw to monkey 5
    If false: throw to monkey 7

Monkey 7:
  Starting items: 81, 78, 82, 76, 79, 80
  Operation: new = old + 3
  Test: divisible by 17
    If true: throw to monkey 3
    If false: throw to monkey 4";
    }
}