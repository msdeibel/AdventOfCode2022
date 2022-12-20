using System.Runtime.InteropServices;

namespace aoc2022;

public class Aoc20221220 : AocBase
{
    public List<(int initialPosition, int value)> InitialLayout;

    private int _itemCount;
    private int _maxIndex;

    public Aoc20221220(string rawInput, int numberOfMoves)
        : base(rawInput)
    {
        _itemCount = InputRows.Count();
        _maxIndex = _itemCount - 1;

        StoreInitialLayout();

        for (int i = 0; i < Math.Min(numberOfMoves, InitialLayout.Count); i++)
        {
            var currentItem = InitialLayout.Single(item => item.initialPosition == i);

            if (currentItem.value == 0)
            {
                continue;
            }

            var currentPosition = InitialLayout.IndexOf(currentItem);
            var resultingPosition = currentPosition + currentItem.value;

            while (resultingPosition > _maxIndex)
            {
                resultingPosition -= _maxIndex;
            }
            while (resultingPosition <= 0)
            {
                resultingPosition += _maxIndex;
            }

            InitialLayout.RemoveAt(currentPosition);
            InitialLayout.Insert(resultingPosition,currentItem);

        }
    }

    private void StoreInitialLayout()
    {
        InitialLayout = new List<(int initialPosition, int value)>(_itemCount);

        for (int i = 0; i < _itemCount; i++)
        {
            InitialLayout.Add((i, int.Parse(InputRows.ElementAt(i))));
        }
    }
}
