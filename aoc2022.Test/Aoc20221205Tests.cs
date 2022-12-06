namespace aoc2022.Test;

public class Aoc20221205Tests
{
    [Fact]
    public void StartingConfigurationIsRead()
    {
        var aoc20220512 = new Aoc20221205(ExampleInput());

        Assert.Equal(9, aoc20220512.InputRows.Count());
    }


    [Fact]
    public void ExampleStackConfigRows()
    {
        var aoc20220512 = new Aoc20221205(ExampleInput());

        Assert.Equal(4, aoc20220512.StackConfigRows.Count());
    }

    [Fact]
    public void ExampleMoveRows()
    {
        var aoc20220512 = new Aoc20221205(ExampleInput());

        Assert.Equal(4, aoc20220512.MoveRows.Count());
    }

    [Fact]
    public void ExampleNumberOfStacks()
    {
        var aoc20220512 = new Aoc20221205(ExampleInput());

        Assert.Equal(3, aoc20220512.NumberOfStacks);
    }

    [Fact]
    public void ExampleStacksAreCreated()
    {
        var aoc20220512 = new Aoc20221205(ExampleInput());

        Assert.Equal(3, aoc20220512.Stacks.Count);
    }

    //[Fact]
    //public void StacksAreFilled()
    //{
    //    var aoc20220512 = new Aoc20221205(ExampleInput());

    //    Assert.Equal(3, aoc20220512.Stacks.Count);

    //    Assert.Equal("[N]", aoc20220512.Stacks.ElementAt(0).Pop());
    //    Assert.Equal("[Z]", aoc20220512.Stacks.ElementAt(0).Pop());

    //    Assert.Equal("[D]", aoc20220512.Stacks.ElementAt(1).Pop());

    //    Assert.Equal("[P]", aoc20220512.Stacks.ElementAt(2).Pop());
    //}

    //[Fact]
    //public void ExampleCratesHaveBeenMoved()
    //{
    //    var aoc20220512 = new Aoc20221205(ExampleInput());
            
    //    //Assert.Equal("[C]", aoc20220512.Stacks.ElementAt(0).Peek());

    //    //Assert.Equal("[M]", aoc20220512.Stacks.ElementAt(1).Peek());

    //    //Assert.Equal("[Z]", aoc20220512.Stacks.ElementAt(2).Peek());

    //    Assert.Equal("CMZ", aoc20220512.TopCrates);
    //}

    //[Fact]
    //public void TaskCratesHaveBeenMoved()
    //{
    //    var aoc20220512 = new Aoc20221205(TaskInput());

    //    //Assert.Equal("[C]", aoc20220512.Stacks.ElementAt(0).Peek());

    //    //Assert.Equal("[M]", aoc20220512.Stacks.ElementAt(1).Peek());

    //    //Assert.Equal("[Z]", aoc20220512.Stacks.ElementAt(2).Peek());

    //    Assert.Equal("CWMTGHBDW", aoc20220512.TopCrates);
    //}

    [Fact]
    public void Task2CratesHaveBeenMoved()
    {
        var aoc20220512 = new Aoc20221205(TaskInput());

        //Assert.Equal("[C]", aoc20220512.Stacks.ElementAt(0).Peek());

        //Assert.Equal("[M]", aoc20220512.Stacks.ElementAt(1).Peek());

        //Assert.Equal("[Z]", aoc20220512.Stacks.ElementAt(2).Peek());

        Assert.Equal("SSCGWJCRB", aoc20220512.TopCrates);
    }

    private string ExampleInput()
    {
        return @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";
    }

    private string TaskInput()
    {
        return @"                [M]     [V]     [L]
[G]             [V] [C] [G]     [D]
[J]             [Q] [W] [Z] [C] [J]
[W]         [W] [G] [V] [D] [G] [C]
[R]     [G] [N] [B] [D] [C] [M] [W]
[F] [M] [H] [C] [S] [T] [N] [N] [N]
[T] [W] [N] [R] [F] [R] [B] [J] [P]
[Z] [G] [J] [J] [W] [S] [H] [S] [G]
 1   2   3   4   5   6   7   8   9 

move 1 from 5 to 2
move 7 from 7 to 1
move 1 from 1 to 7
move 1 from 4 to 1
move 7 from 9 to 1
move 1 from 3 to 7
move 4 from 5 to 4
move 6 from 4 to 9
move 2 from 7 to 6
move 6 from 8 to 2
move 2 from 4 to 5
move 2 from 3 to 7
move 11 from 1 to 4
move 6 from 6 to 1
move 3 from 5 to 3
move 5 from 9 to 8
move 1 from 2 to 3
move 2 from 7 to 9
move 7 from 1 to 2
move 1 from 5 to 3
move 1 from 5 to 3
move 5 from 8 to 5
move 3 from 5 to 4
move 1 from 1 to 7
move 1 from 3 to 8
move 2 from 6 to 3
move 3 from 3 to 4
move 1 from 6 to 2
move 5 from 4 to 2
move 2 from 5 to 3
move 2 from 7 to 1
move 1 from 8 to 1
move 7 from 1 to 7
move 4 from 4 to 2
move 7 from 4 to 1
move 10 from 1 to 5
move 10 from 5 to 2
move 11 from 2 to 3
move 1 from 1 to 6
move 1 from 4 to 7
move 4 from 7 to 1
move 6 from 2 to 5
move 2 from 1 to 3
move 1 from 9 to 5
move 2 from 9 to 6
move 1 from 6 to 1
move 3 from 5 to 4
move 20 from 3 to 9
move 3 from 7 to 1
move 3 from 5 to 2
move 3 from 4 to 8
move 3 from 1 to 3
move 3 from 1 to 2
move 2 from 6 to 1
move 10 from 9 to 6
move 6 from 6 to 7
move 4 from 6 to 3
move 11 from 2 to 6
move 1 from 8 to 9
move 13 from 2 to 3
move 1 from 1 to 9
move 1 from 9 to 4
move 1 from 8 to 2
move 1 from 8 to 2
move 4 from 7 to 8
move 8 from 6 to 9
move 3 from 2 to 3
move 3 from 8 to 4
move 11 from 9 to 2
move 7 from 9 to 6
move 1 from 1 to 5
move 4 from 4 to 9
move 21 from 3 to 1
move 1 from 3 to 9
move 7 from 6 to 3
move 6 from 1 to 2
move 13 from 1 to 5
move 2 from 1 to 2
move 3 from 9 to 3
move 2 from 2 to 3
move 2 from 6 to 4
move 3 from 3 to 5
move 13 from 5 to 2
move 5 from 3 to 4
move 2 from 7 to 9
move 2 from 4 to 2
move 1 from 3 to 8
move 1 from 6 to 1
move 4 from 3 to 7
move 2 from 5 to 7
move 1 from 7 to 2
move 1 from 5 to 9
move 4 from 7 to 8
move 1 from 1 to 9
move 6 from 8 to 1
move 4 from 4 to 8
move 25 from 2 to 9
move 1 from 4 to 3
move 1 from 3 to 7
move 4 from 8 to 1
move 1 from 7 to 4
move 3 from 1 to 6
move 5 from 2 to 1
move 1 from 5 to 1
move 1 from 4 to 1
move 24 from 9 to 6
move 9 from 1 to 6
move 1 from 5 to 6
move 1 from 1 to 9
move 1 from 2 to 8
move 1 from 8 to 1
move 3 from 1 to 8
move 36 from 6 to 3
move 2 from 7 to 3
move 1 from 2 to 5
move 1 from 5 to 2
move 1 from 6 to 2
move 10 from 3 to 2
move 3 from 8 to 2
move 1 from 1 to 7
move 2 from 2 to 6
move 10 from 9 to 1
move 2 from 6 to 4
move 13 from 3 to 4
move 8 from 3 to 7
move 8 from 1 to 2
move 5 from 3 to 8
move 3 from 1 to 9
move 1 from 7 to 1
move 7 from 4 to 5
move 1 from 1 to 2
move 14 from 2 to 6
move 2 from 7 to 2
move 8 from 4 to 8
move 3 from 7 to 9
move 2 from 9 to 8
move 2 from 7 to 1
move 1 from 7 to 8
move 1 from 6 to 8
move 1 from 9 to 3
move 4 from 2 to 7
move 6 from 6 to 1
move 3 from 1 to 9
move 1 from 1 to 7
move 6 from 5 to 6
move 1 from 5 to 2
move 1 from 6 to 8
move 5 from 7 to 5
move 1 from 2 to 9
move 2 from 3 to 4
move 9 from 8 to 4
move 8 from 4 to 8
move 6 from 6 to 7
move 5 from 6 to 4
move 7 from 9 to 7
move 7 from 8 to 7
move 5 from 8 to 4
move 3 from 1 to 6
move 1 from 2 to 7
move 1 from 1 to 4
move 4 from 5 to 2
move 2 from 6 to 9
move 1 from 3 to 7
move 1 from 5 to 1
move 1 from 8 to 9
move 1 from 6 to 1
move 1 from 2 to 7
move 2 from 8 to 1
move 2 from 1 to 8
move 3 from 2 to 4
move 1 from 6 to 1
move 17 from 4 to 1
move 3 from 2 to 7
move 13 from 7 to 8
move 1 from 2 to 6
move 14 from 1 to 4
move 2 from 8 to 5
move 1 from 9 to 7
move 2 from 5 to 4
move 1 from 9 to 3
move 5 from 1 to 5
move 3 from 4 to 1
move 1 from 3 to 2
move 7 from 4 to 5
move 9 from 7 to 8
move 5 from 4 to 2
move 1 from 1 to 3
move 1 from 9 to 2
move 15 from 8 to 6
move 1 from 3 to 7
move 11 from 6 to 5
move 1 from 4 to 8
move 3 from 1 to 7
move 5 from 7 to 5
move 27 from 5 to 1
move 8 from 8 to 4
move 1 from 2 to 6
move 3 from 6 to 1
move 9 from 1 to 5
move 5 from 5 to 7
move 2 from 2 to 1
move 2 from 5 to 4
move 6 from 7 to 6
move 1 from 5 to 2
move 1 from 7 to 8
move 4 from 6 to 8
move 5 from 6 to 3
move 1 from 7 to 1
move 5 from 4 to 3
move 6 from 8 to 2
move 1 from 7 to 8
move 2 from 8 to 9
move 10 from 3 to 5
move 9 from 5 to 2
move 3 from 4 to 8
move 1 from 5 to 7
move 2 from 9 to 7
move 2 from 8 to 3
move 1 from 3 to 8
move 19 from 1 to 7
move 4 from 2 to 7
move 2 from 4 to 3
move 3 from 3 to 2
move 2 from 8 to 3
move 2 from 5 to 8
move 1 from 2 to 3
move 2 from 8 to 3
move 5 from 2 to 5
move 9 from 7 to 5
move 13 from 5 to 9
move 7 from 2 to 6
move 2 from 6 to 9
move 1 from 2 to 1
move 5 from 6 to 7
move 1 from 5 to 7
move 6 from 1 to 2
move 5 from 3 to 6
move 6 from 7 to 2
move 3 from 6 to 4
move 3 from 7 to 4
move 12 from 7 to 6
move 5 from 4 to 1
move 2 from 7 to 4
move 3 from 4 to 6
move 16 from 6 to 3
move 4 from 1 to 4
move 1 from 1 to 9
move 3 from 9 to 2
move 1 from 4 to 6
move 9 from 3 to 7
move 2 from 6 to 3
move 3 from 3 to 9
move 15 from 2 to 7
move 19 from 7 to 4
move 15 from 9 to 2
move 16 from 2 to 8
move 6 from 3 to 5
move 4 from 7 to 5
move 15 from 8 to 7
move 19 from 4 to 2
move 1 from 8 to 3
move 16 from 2 to 1
move 9 from 7 to 6
move 7 from 2 to 8
move 2 from 2 to 7
move 1 from 9 to 5
move 1 from 3 to 4
move 6 from 1 to 2
move 8 from 5 to 1
move 1 from 5 to 1
move 18 from 1 to 8
move 7 from 7 to 5
move 7 from 5 to 3
move 4 from 3 to 6
move 13 from 8 to 5
move 12 from 8 to 1
move 5 from 1 to 6
move 15 from 5 to 4
move 1 from 1 to 6
move 12 from 6 to 3
move 8 from 3 to 4
move 2 from 7 to 3
move 9 from 3 to 1
move 5 from 2 to 9
move 16 from 4 to 3
move 10 from 1 to 3
move 2 from 1 to 5
move 1 from 3 to 1
move 5 from 6 to 1
move 4 from 9 to 3
move 1 from 2 to 8
move 1 from 8 to 1
move 1 from 9 to 8
move 2 from 5 to 9
move 9 from 4 to 1
move 3 from 1 to 3
move 2 from 6 to 8
move 3 from 8 to 5
move 2 from 1 to 5
move 2 from 9 to 8
move 1 from 8 to 6
move 2 from 5 to 3
move 19 from 3 to 1
move 2 from 4 to 2
move 1 from 5 to 6
move 2 from 2 to 3
move 1 from 8 to 6
move 8 from 3 to 9
move 6 from 3 to 7
move 2 from 6 to 2
move 1 from 6 to 1
move 1 from 1 to 8
move 1 from 8 to 9
move 1 from 7 to 3
move 19 from 1 to 5
move 21 from 5 to 2
move 13 from 2 to 6
move 13 from 1 to 8
move 7 from 9 to 7
move 2 from 9 to 2
move 10 from 8 to 3
move 1 from 1 to 6
move 10 from 2 to 4
move 11 from 3 to 5
move 8 from 5 to 6
move 1 from 3 to 7
move 2 from 8 to 6
move 2 from 2 to 8
move 3 from 7 to 6
move 2 from 8 to 6
move 1 from 1 to 2
move 24 from 6 to 5
move 2 from 3 to 8
move 1 from 8 to 6
move 7 from 7 to 9
move 4 from 6 to 9
move 1 from 8 to 9
move 21 from 5 to 9
move 2 from 7 to 2
move 1 from 8 to 5
move 1 from 7 to 3
move 12 from 9 to 6
move 6 from 6 to 3
move 12 from 9 to 4
move 4 from 5 to 6
move 13 from 4 to 2
move 8 from 4 to 8
move 10 from 6 to 8
move 11 from 8 to 9
move 4 from 8 to 4
move 2 from 4 to 3
move 8 from 3 to 8
move 2 from 6 to 8
move 1 from 3 to 8
move 6 from 2 to 4
move 1 from 4 to 8
move 1 from 9 to 7
move 13 from 8 to 4
move 1 from 7 to 1
move 1 from 1 to 4
move 8 from 4 to 7
move 3 from 5 to 7
move 19 from 9 to 7
move 3 from 2 to 7
move 1 from 8 to 2
move 13 from 7 to 6
move 1 from 2 to 4
move 4 from 6 to 2
move 1 from 8 to 3
move 7 from 6 to 8
move 1 from 6 to 2
move 1 from 2 to 7
move 9 from 2 to 3
move 1 from 6 to 2
move 21 from 7 to 5
move 9 from 5 to 3
move 19 from 3 to 9
move 5 from 8 to 5
move 2 from 2 to 1
move 2 from 1 to 8
move 6 from 4 to 5
move 3 from 8 to 7
move 15 from 9 to 2
move 2 from 2 to 5
move 3 from 9 to 6
move 5 from 4 to 5
move 11 from 2 to 6
move 1 from 8 to 6
move 1 from 9 to 5
move 1 from 7 to 3
move 6 from 5 to 6
move 1 from 4 to 6
move 1 from 3 to 4
move 13 from 5 to 2
move 16 from 6 to 9
move 4 from 4 to 5
move 2 from 6 to 2
move 2 from 6 to 4
move 2 from 4 to 5
move 2 from 7 to 8
move 2 from 6 to 3
move 2 from 5 to 8
move 14 from 5 to 7
move 4 from 8 to 1
move 4 from 1 to 6
move 1 from 3 to 9
move 1 from 6 to 1
move 2 from 7 to 3
move 2 from 3 to 7
move 2 from 5 to 2
move 9 from 9 to 2
move 13 from 7 to 3
move 12 from 3 to 9
move 2 from 6 to 8
move 14 from 2 to 9
move 2 from 8 to 9
move 10 from 2 to 1
move 1 from 7 to 4
move 2 from 3 to 8
move 4 from 2 to 1
move 1 from 8 to 3
move 1 from 2 to 6
move 1 from 8 to 3
move 4 from 9 to 4
move 1 from 3 to 5
move 1 from 5 to 1
move 1 from 3 to 9
move 12 from 1 to 8
move 10 from 8 to 5
move 7 from 5 to 6
move 1 from 1 to 9
move 3 from 5 to 1
move 1 from 1 to 3
move 16 from 9 to 7
move 4 from 4 to 3
move 1 from 4 to 9
move 15 from 7 to 8
move 15 from 9 to 1
move 8 from 1 to 6
move 1 from 9 to 3
move 17 from 6 to 2
move 1 from 9 to 1
move 15 from 2 to 7
move 14 from 8 to 9
move 12 from 7 to 9
move 12 from 9 to 3
move 3 from 7 to 9
move 1 from 7 to 4
move 7 from 9 to 6
move 1 from 4 to 6
move 11 from 9 to 6
move 2 from 1 to 2
move 18 from 6 to 4
move 4 from 2 to 7
move 2 from 7 to 3
move 2 from 7 to 8
move 4 from 1 to 5
move 1 from 9 to 2
move 2 from 5 to 4
move 5 from 1 to 3
move 2 from 3 to 7
move 2 from 3 to 9
move 1 from 6 to 7
move 1 from 2 to 9
move 2 from 8 to 1
move 3 from 1 to 3
move 2 from 5 to 8
move 2 from 3 to 5
move 1 from 5 to 2
move 1 from 1 to 3
move 1 from 9 to 2
move 1 from 9 to 1
move 3 from 7 to 6
move 1 from 1 to 9
move 2 from 8 to 9
move 1 from 2 to 3
move 2 from 8 to 2
move 2 from 6 to 5
move 1 from 8 to 5
move 3 from 2 to 5
move 3 from 4 to 8
move 1 from 8 to 2
move 3 from 9 to 7
move 3 from 7 to 1
move 1 from 9 to 6
move 3 from 1 to 2
move 2 from 8 to 7
move 2 from 7 to 9
move 2 from 6 to 5
move 3 from 5 to 3
move 1 from 2 to 5
move 3 from 2 to 7
move 2 from 5 to 6
move 15 from 4 to 9
move 1 from 3 to 1
move 25 from 3 to 4
move 3 from 7 to 3
move 5 from 9 to 5
move 10 from 9 to 5
move 9 from 5 to 1
move 5 from 5 to 2
move 1 from 6 to 7
move 5 from 5 to 8";
    }
}