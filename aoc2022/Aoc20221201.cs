namespace aoc2022;

public class Aoc20221201
{

    public string RawInput { get; private set; }

    private IList<Elf> Elves { get; set; }

    public int ElfCount => Elves.Count;

    public Aoc20221201(string rawInput)
    {
        RawInput = rawInput;

        Elves = new List<Elf>();

        SplitInputIntoElves();
    }

    private void SplitInputIntoElves()
    {
        Elf? e = null;

        foreach (var s in RawInput.Split("\r\n"))
        {
            if (e == null 
                || string.IsNullOrWhiteSpace(s))
            {
                e = new Elf();
                Elves.Add(e);

                continue;
            }

            e.AddPackage(int.Parse(s));
        }
    }

    public int MaxCaloriesForTopOneElf()
    {
        var maximumElf = Elves.MaxBy(e => e.TotalCaloriesCarried);

        return maximumElf?.TotalCaloriesCarried ?? 0;
    }

    public int MaxCaloriesForTopThreeElves()
    {
        return Elves.OrderByDescending(e => e.TotalCaloriesCarried)
            .Take(3)
            .Select(e => e.TotalCaloriesCarried)
            .Sum();
    }
}

public class Elf
{
    private IList<int> Calories { get; }

    public int TotalCaloriesCarried => Calories.Sum();

    public Elf()
    {
        Calories = new List<int>();
    }

    public void AddPackage(int calories)
    {
        Calories.Add(calories);
    }
}