using System.Runtime.InteropServices;

namespace aoc2022;

public class Aoc20221220 : AocBase
{
    private const long DecryptionKey = 811589153;

    public List<(int initialPosition, long value)> InitialLayout;

    private int _itemCount;
    private long _maxIndex;

    public Aoc20221220(string rawInput, int numberOfMoves)
        : base(rawInput)
    {
        _itemCount = InputRows.Count();
        _maxIndex = (long)_itemCount - 1l;

        StoreInitialLayout();

        for (int r = 0; r < 10; r++)
        {
            for (int i = 0; i < Math.Min(numberOfMoves, InitialLayout.Count); i++)
            {
                var currentItem = InitialLayout.Single(item => item.initialPosition == i);

                if (currentItem.value == 0)
                {
                    continue;
                }

                var currentPosition = InitialLayout.IndexOf(currentItem);
                long resultingPosition = (long)currentPosition + currentItem.value;

                while (resultingPosition > _maxIndex * 10_000)
                {
                    resultingPosition -= _maxIndex * 10_000;
                }
                while (resultingPosition > _maxIndex * 1_000)
                {
                    resultingPosition -= _maxIndex * 1_000;
                }
                while (resultingPosition > _maxIndex)
                {
                    resultingPosition -= _maxIndex;
                }
                while (resultingPosition <= 0)
                {
                    while (resultingPosition < (_maxIndex * -10_000))
                    {
                        resultingPosition += _maxIndex * 10_000;
                    }
                    while (resultingPosition < (_maxIndex * -1_000))
                    {
                        resultingPosition += _maxIndex * 1_000;
                    }

                    resultingPosition += _maxIndex;
                }

                InitialLayout.RemoveAt(currentPosition);
                InitialLayout.Insert((int)resultingPosition, currentItem);

            }
        }
    }

    private void StoreInitialLayout()
    {
        InitialLayout = new List<(int initialPosition, long value)>(_itemCount);

        for (int i = 0; i < _itemCount; i++)
        {
            InitialLayout.Add((i, long.Parse(InputRows.ElementAt(i)) * DecryptionKey));
        }
    }
}
