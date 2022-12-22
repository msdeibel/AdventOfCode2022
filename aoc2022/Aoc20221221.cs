using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace aoc2022;

public class Aoc20221221 : AocBase
{
    private readonly Dictionary<string, Monkey> _name2Monkey;
    public IReadOnlyDictionary<string, Monkey> Name2Monkey => _name2Monkey;

    public Aoc20221221(string rawInput)
        : base(rawInput)
    {
        _name2Monkey = new Dictionary<string, Monkey>();

        InitMokeys();

        BuildMonkeyTree();

        long h = 10_000_000_001L;
        long factor = 10_000_000_000;
        long direction = 1; //1 ++; -1 --
        long compareResult;
        long previousCompareResult = -1;

        do
        {
            _name2Monkey["humn"].SetValue(h);

            compareResult = _name2Monkey["root"].GetValue();

            if (compareResult != previousCompareResult)
            {
                direction *= -1;
                factor = factor >= 10
                    ? factor / 10
                    : 1;
            }

            previousCompareResult = compareResult;
            h += factor * direction;

        } while (compareResult != 0);
    }

    private void BuildMonkeyTree()
    {
        foreach (var monkey in Name2Monkey.Values)
        {
            if (monkey.HasChildren)
            {
                monkey.SetLeftMonkey(Name2Monkey[monkey.LeftMonkeyName]);
                monkey.SetRightMonkey(Name2Monkey[monkey.RightMonkeyName]);
            }
        }
    }

    private void InitMokeys()
    {
        var operationMatcher = new Regex("(\\w{4}): (\\w{4}) ([\\+\\-\\*/]) (\\w{4})");
        var valueMatcher = new Regex("(\\w{4}): (\\d+)");

        foreach (var r in InputRows)
        {
            if (operationMatcher.IsMatch(r))
            {
                var opMonkey = operationMatcher.Match(r);

                _name2Monkey.Add(opMonkey.Groups[1].Value, new Monkey(opMonkey.Groups[1].Value,
                    opMonkey.Groups[2].Value,
                    opMonkey.Groups[3].Value.First(),
                    opMonkey.Groups[4].Value,
                    null
                ));
            }
            else
            {
                var valMonkey = valueMatcher.Match(r);

                _name2Monkey.Add(valMonkey.Groups[1].Value, new Monkey(valMonkey.Groups[1].Value,
                    null,
                    null,
                    null,
                    long.Parse(valMonkey.Groups[2].Value)
                ));
            }
        }
    }

    public class Monkey
    {
        public string Name { get; }

        private char? _mathOperator;

        private Monkey _leftMonkey;
        public Monkey LeftMonkey => _leftMonkey;

        private Monkey _rightMonkey;
        public Monkey RightMonkey => _rightMonkey;

        private string? _leftMonkeyName;
        public string LeftMonkeyName => _leftMonkeyName;

        private string? _rightMonkeyName;
        public string RightMonkeyName => _rightMonkeyName;

        public bool HasChildren => _leftMonkeyName != null && _rightMonkeyName != null;

        private long? _value;

        public Monkey(string name, string? leftMonkeyName, char? mathOperator, string? rightMonkeyName, long? value)
        {
            Name = name;
            _mathOperator = mathOperator;
            _value = value;
            _leftMonkeyName = leftMonkeyName;
            _rightMonkeyName = rightMonkeyName;
        }

        public void SetLeftMonkey(Monkey leftMonkey)
        {
            _leftMonkey = leftMonkey;
        }

        public void SetRightMonkey(Monkey rightMonkey)
        {
            _rightMonkey = rightMonkey;
        }

        public long GetValue()
        {
            if (Name == "root")
            {
                var lv = _leftMonkey.GetValue();
                var rv = _rightMonkey.GetValue();

                return lv.CompareTo(rv);
            }

            if (!HasChildren)
            {
                return _value.Value;
            }

            var leftValue = _leftMonkey.GetValue();
            var rightValue = _rightMonkey.GetValue();

            return _mathOperator switch
            {
                '+' => leftValue + rightValue,
                '-' => leftValue - rightValue,
                '*' => leftValue * rightValue,
                _ => leftValue / rightValue
            };
        }

        internal void SetValue(long value)
        {
            _value = value;
        }
    }
}
