using System.Collections.Immutable;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace aoc2022;

public class Aoc20221214 : AocBase
{
    private readonly IList<Match> _coordinates;

    private bool _sandSet;

    public IReadOnlyList<Match> Coordinates => _coordinates.ToImmutableList();

    public int MinColIndex { get; private set; }
    public int MaxColIndex { get; private set; }

    public int MaxRowIndex { get; private set; }

    public Structure[,] Cave;


    private readonly (int column, int row) _sandstart = (500, 0);

    public Aoc20221214(string rawInput)
        : base(rawInput)
    {
        var coordinatesMatcher = new Regex("(\\d+,\\d+)", RegexOptions.Compiled);

        _coordinates = coordinatesMatcher.Matches(rawInput).ToList();

        MinColIndex = _coordinates.Select(m => int.Parse(m.Value.Split(',').First())).Min();
        MaxColIndex = _coordinates.Select(m => int.Parse(m.Value.Split(',').First())).Max();

        MaxRowIndex = _coordinates.Select(m => int.Parse(m.Value.Split(',').Last())).Max();



        InitCave();

        SetRocks();

        var dropToVoid = false;
        var hasStopped = false;
        (int row, int column) grainPosition = (0, 500 - MinColIndex);

        do
        {
            grainPosition = (0, 500 - MinColIndex);
            hasStopped = false;

            do
            {
                if (grainPosition.row == Cave.GetLength(0) - 1)
                {
                    dropToVoid = true;
                    hasStopped = true;
                }
                else if (Cave[grainPosition.row + 1, grainPosition.column].IsAir)
                {
                    grainPosition = (grainPosition.row + 1, grainPosition.column);
                }
                else
                {
                    // on left boundary
                    if (grainPosition.column == 0)
                    {
                        dropToVoid = true;
                        hasStopped = true;
                    }
                    else
                    {
                        // can move left down
                        if (Cave[grainPosition.row + 1, grainPosition.column - 1].IsAir)
                        {
                            grainPosition = (grainPosition.row + 1, grainPosition.column - 1);
                        }
                        // on right boundary
                        else if (grainPosition.column == MaxColIndex)
                        {
                            dropToVoid = true;
                            hasStopped = true;
                        }
                        // can move right down
                        else if (Cave[grainPosition.row + 1, grainPosition.column + 1].IsAir)
                        {
                            grainPosition = (grainPosition.row + 1, grainPosition.column + 1);
                        }
                        else
                        {
                            hasStopped = true;
                            Cave[grainPosition.row, grainPosition.column].ToSand();
                        }
                    }
                }
            } while (!hasStopped);

        } while (!dropToVoid);


        //var dropResult = false;

        //var sandspots = 0;
        //var oldsandspots = 0;
        //var grainCount = 0;


        //do
        //{
        //    _sandSet = false;
        //    oldsandspots = sandspots;
        var    sandspots = 0;

        //    //for (int i = 0; i < 30; i++)
        //    //{
        //    dropResult = Cave[0, 500 - MinColIndex].DropSand();

        //    grainCount++;
        //    //}

        for (int i = 0; i < Cave.GetLength(0); i++)
        {
            for (int j = 0; j < Cave.GetLength(1); j++)
            {
                if (Cave[i, j].IsSand)
                {
                    sandspots++;
                }
            }
        }

        //} while (dropResult && grainCount < 1_500);


    }

    private void SetRocks()
    {
        foreach (var inputRow in InputRows)
        {
            var coordinatesMatcher = new Regex("(\\d+,\\d+)", RegexOptions.Compiled);

            var coordinates = coordinatesMatcher.Matches(inputRow).Select(m => m.Value).ToArray();

            for (int i = 0; i < coordinates.Length - 1; i++)
            {
                var relevantCoords = coordinates.Skip(i).Take(2).ToArray();

                var coord1 = relevantCoords.First().Split(',').Select(int.Parse);
                var coord2 = relevantCoords.Last().Split(',').Select(int.Parse);

                // Gleiche Spalte
                if (coord1.ElementAt(0) == coord2.ElementAt(0))
                {
                    int from = Math.Min(coord1.ElementAt(1), coord2.ElementAt(1));
                    int to = Math.Max(coord1.ElementAt(1), coord2.ElementAt(1));

                    for (int row = from; row <= to; row++)
                    {
                        Cave[row, coord1.ElementAt(0) - MinColIndex].ToRock();
                    }
                }
                // Gleiche Zeile
                else
                {
                    int from = Math.Min(coord1.ElementAt(0), coord2.ElementAt(0));
                    int to = Math.Max(coord1.ElementAt(0), coord2.ElementAt(0));

                    for (int col = from; col <= to; col++)
                    {
                        Cave[coord1.ElementAt(1), col - MinColIndex].ToRock();
                    }
                }
            }
        }
    }

    private void InitCave()
    {
        var indexDifference = MaxColIndex - MinColIndex;
        var columnCount = indexDifference + 1;

        Cave = new Structure[MaxRowIndex + 1, columnCount];

        for (var r = MaxRowIndex; r >= 0; r--)
        {
            for (var c = 0; c < columnCount; c++)
            {
                if (r == MaxRowIndex)
                {
                    Cave[r, c] = new Structure(true, null, null, null);
                }
                else
                {
                    Cave[r, c] = new Structure(true,
                        c == 0 ? null : Cave[r + 1, c - 1],
                        Cave[r + 1, c],
                        c == columnCount - 1 ? null : Cave[r + 1, c + 1]);
                }
            }
        }
    }
}

public delegate bool TrickleIn();

public class Structure
{
    public bool IsAir;
    public bool IsRock;
    public bool IsSand => !IsAir && !IsRock;

    //private Structure? _belowLeft;
    //private Structure? _belowDown;
    //private Structure? _belowRight;

    public event TrickleIn? TrickleLeft;
    public event TrickleIn? TrickleDown;
    public event TrickleIn? TrickleRight;

    public Structure(bool isAir, Structure? belowLeft, Structure? belowDown, Structure? belowRight)
    {
        IsAir = isAir;
        IsRock = !isAir;

        if (belowLeft != null)
        {
            TrickleLeft += belowLeft.TrickleHandler;
        }

        if (belowDown != null)
        {
            TrickleDown += belowDown.TrickleHandler;
        }

        if (belowRight != null)
        {
            TrickleRight += belowRight.TrickleHandler;
        }
    }

    public void ToRock()
    {
        IsAir = false;
        IsRock = true;
    }

    public void ToSand()
    {
        IsAir = false;
        IsRock = false;
    }

    public bool TrickleHandler()
    {
        //if (TrickleLeft == null &&)
        //{
        //    return false;
        //}

        if (IsAir)
        {
            if (TrickleDown == null)
            {
                return false;
            }

            if (TrickleDown?.Invoke() == true)
            {
                return true;
            }

            if (TrickleDown?.Invoke() == false)
            {
                if (TrickleLeft == null)
                {
                    return true;
                }

                if (TrickleRight == null)
                {
                    return true;
                }

                if (TrickleLeft?.Invoke() == true) 
                {
                    return true;
                }

                if (TrickleRight?.Invoke() == true)
                {
                    return true;
                }

                IsAir = false;

                return true;
            }
        }

        if (IsRock || IsSand)
        {
            if (TrickleLeft == null)
            {
                return false;
            }

            //if (TrickleLeft?.Invoke() == true)
            //{
            //    return true;
            //}
        }

        return false;
    }

    public bool DropSand()
    {
        return TrickleDown?.Invoke() == true;
    }
}


