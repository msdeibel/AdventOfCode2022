using System.Collections.Immutable;

namespace aoc2022;

public class Aoc20221208 : AocBase
{
    public List<Tree> Trees { get; }

    public IReadOnlyList<Tree> OuterTrees => Trees.Where(t => t.Row == 0
                                                        || t.Row == InputRows.Count() - 1
                                                        || t.Column == 0
                                                        || t.Column == InputRows.ElementAt(0).Length - 1).ToImmutableList();

    public IReadOnlyList<Tree> VisibleTrees => Trees.Where(t => IsTreeVisible(t.Row, t.Column)).ToImmutableList();

    public IReadOnlyList<int> ScenicViews => Trees
                                            .Where(t => !OuterTrees.Contains(t))
                                            .Select(ScenicViewAt)
                                            .ToImmutableList();

    public Aoc20221208(string rawInput)
        : base(rawInput)
    {
        Trees = new List<Tree>(InputRows.Count() * InputRows.ElementAt(0).Length);

        for (var r = 0; r < InputRows.Count(); r++)
        {
            for (var c = 0; c < InputRows.ElementAt(0).Length; c++)
            {
                Trees.Add(new Tree(InputRows.ElementAt(r)[c]-48, r, c));
            }
        }
    }

    public IEnumerable<Tree> GetVisibleTrees()
    {
        var outerTrees = OuterTrees; 

        return outerTrees;
    }

    public bool IsTreeVisible(int rowIndex, int columnIndex)
    {
        if (OuterTrees.Any(t => t.Row == rowIndex && t.Column == columnIndex))
        {
            return true;
        }

        var heightAtPosition = Trees.Single(t => t.Row == rowIndex && t.Column == columnIndex).Height;

        var maxTreeHeightLeft =
            Trees.Where(t => t.Row == rowIndex && t.Column < columnIndex).Select(t => t.Height).Max();

        var maxTreeHeightRight =
            Trees.Where(t => t.Row == rowIndex && t.Column > columnIndex).Select(t => t.Height).Max();

        var maxTreeHeightUp =
            Trees.Where(t => t.Row < rowIndex && t.Column == columnIndex).Select(t => t.Height).Max();

        var maxTreeHeightDown =
            Trees.Where(t => t.Row > rowIndex && t.Column == columnIndex).Select(t => t.Height).Max();

        return heightAtPosition > maxTreeHeightLeft
                || heightAtPosition > maxTreeHeightRight
                || heightAtPosition > maxTreeHeightUp
                || heightAtPosition > maxTreeHeightDown;
    }

    public int ScenicViewAt(Tree tree)
    {
        var left = 0;

        for (var c = tree.Column-1; c >= 0; c--)
        {
            left++;

            if (Trees.Single(t => t.Row == tree.Row && t.Column == c).Height >= tree.Height)
            {
                break;
            }
        }

        var right = 0;

        for (var c = tree.Column+1; c < InputRows.ElementAt(0).Length; c++)
        {
            right++;

            if (Trees.Single(t => t.Row == tree.Row && t.Column == c).Height >= tree.Height)
            {
                break;
            }
        }

        var up = 0;

        for (var r = tree.Row-1; r >= 0; r--)
        {
            up++;

            if (Trees.Single(t => t.Row == r && t.Column == tree.Column).Height >= tree.Height)
            {
                break;
            }
        }

        var down = 0;

        for (var r = tree.Row+1;r < InputRows.Count(); r++)
        {
            down++;
            
            if (Trees.Single(t => t.Row == r && t.Column == tree.Column).Height >= tree.Height)
            {
                break;
            }
        }

        return left * right * up * down;
    }
}

public class Tree
{
    public int Height { get; }
    public int Row { get; }
    public int Column { get; }

    public Tree (int height, int row, int column)
    {
        Height = height;
        Row = row;
        Column = column;
    }
}
