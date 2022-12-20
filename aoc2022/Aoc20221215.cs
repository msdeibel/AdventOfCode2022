using System.Collections.Immutable;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Xml;

namespace aoc2022;

public class Aoc20221215 : AocBase
{
    private List<MapPoint> _mapPoints;
    public IReadOnlyList<MapPoint> MapPoints => _mapPoints.ToImmutableList();

    private int _minX;
    private int _maxX;
    public int _minY;
    private int _maxY;

    public int Columns { get; private set; }
    public int Rows { get; private set; }

    public char[,] Map;


    public Aoc20221215(string rawInput)
        : base(rawInput)
    {
        InitSensorsAndBeacons();

        CalculateGridSize();

        InitMap();

        SetSensorsAndBeacons();

        _mapPoints = _mapPoints.DistinctBy(p => new { p.X, p.Y }).ToList();

        var sensors = _mapPoints.Where(p => p.IsSensor).ToArray();

        var minMaxIn2Mil = new List<(int, int)>(30);

        //var _2milCounter = 0;

        // SetMarkers
        for (int i = 0; i < sensors.Length; i++)
        //foreach (var s in sensors)
        {
            var d = sensors[i].DistanceToNearesBeacon;

            var rc = RelativeCoordinatesFor(sensors[i]);

            var start = rc.y > 2_000_000
                ? rc.y - d - 2
                : rc.y;

            var end = rc.y > 2_000_000
                ? rc.y
                : rc.y + d + 2;

            //minMaxIn2Mil.Add((s.X - (d - Math.Abs(2_000_000 - s.Y)), s.X + (d - Math.Abs(2_000_000 - s.Y))));

            _mapPoints = _mapPoints.DistinctBy(p => new { p.X, p.Y }).ToList();

            for (int r = rc.y - d - 1; r < rc.y + d + 1; r++)
            {
                //if (r != 2_000_000) { continue; }



                var upDown = Math.Abs(rc.y - r);

                for (int c = rc.x - d + upDown; c < rc.x + d - upDown + 1; c++)
                {
                    var mp = _mapPoints.SingleOrDefault(p => p.X == c && p.Y == r);

                    if (mp == null)
                    {
                        _mapPoints.Add(new MapPoint() { IsBeacon = false, IsExcluded = true, IsSensor = false, X = c, Y = r, NearestBeacon = null });
                    }
                    else if (!mp.IsBeacon && !mp.IsSensor)
                    {
                        mp.IsExcluded = true;
                    }

                    //_2milCounter++;

                    if (Map[r, c] == '.')
                    {
                        Map[r, c] = '#';
                    }
                }
            }
            }
        }

    private void SetSensorsAndBeacons()
    {
        foreach (var m in _mapPoints)
        {
            var rc = RelativeCoordinatesFor(m);
            Map[rc.y, rc.x] = m.IsBeacon ? 'B' : 'S';
        }
    }

    private void InitMap()
    {
        Map = new char[Rows, Columns];

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                Map[i, j] = '.';
            }
        }
    }

    private void InitSensorsAndBeacons()
    {
        _mapPoints = new List<MapPoint>(InputRows.Count() * 2);

        var inputMatcher =
            new Regex("(Sensor at x=)(\\d+)(, y=)(\\d+)(: closest beacon is at x=)(-?\\d+)(, y=)(-?\\d+)");

        foreach (var r in InputRows)
        {
            var matchingResult = inputMatcher.Match(r);

            var sensorX = int.Parse(matchingResult.Groups[2].Value);
            var sensorY = int.Parse(matchingResult.Groups[4].Value);
            var beaconX = int.Parse(matchingResult.Groups[6].Value);
            var beaconY = int.Parse(matchingResult.Groups[8].Value);

            var b = new MapPoint()
                { IsBeacon = true, IsSensor = false, X = beaconX, Y = beaconY, NearestBeacon = null };

            _mapPoints.Add(new MapPoint() { IsBeacon = false, IsSensor = true, X = sensorX, Y = sensorY, NearestBeacon = b});

            if (!_mapPoints.Any(p => p.X == b.X && p.Y == b.Y))
            {
                _mapPoints.Add(b);
            }
        }
    }

    private void CalculateGridSize()
    {
        var sensors = _mapPoints.Where(p => p.IsSensor).ToArray();

        foreach (var s in sensors)
        {
            var d = s.DistanceToNearesBeacon;

            _minX = Math.Min(_minX, s.X - d);
            _maxX = Math.Max(_maxX, s.X + d);

            _minY = Math.Min(_minY, s.Y - d);
            _maxY = Math.Max(_maxY, s.Y + d);
        }
        
        Columns = (_maxX - _minX) + 1;
        Rows = (_maxY - _minY) + 1;
    }

    private (int x, int y) RelativeCoordinatesFor(MapPoint mapPoint)
    {
        return (mapPoint.X - _minX, mapPoint.Y - _minY);

        //return (mapPoint.X, mapPoint.Y);
    }
}

public record MapPoint
{
    public int X;
    public int Y;

    public bool IsSensor;
    public bool IsBeacon;
    public bool IsExcluded;

    public MapPoint? NearestBeacon;

    public int DistanceToNearesBeacon => ManhattanDistanceTo(NearestBeacon);

    public int ManhattanDistanceTo(MapPoint otherMapPoint)
    {
        return otherMapPoint != null 
            ? Math.Abs(X - otherMapPoint.X) + Math.Abs(Y - otherMapPoint.Y)
            : 0;
    }
}