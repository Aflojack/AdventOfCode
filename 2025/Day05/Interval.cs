using System;

namespace Day05;

public class Interval
{
    public long StartPoint {get; private set;}
    public long EndPoint {get; private set;}

    public Interval(string range)
    {
        var rangeSplit = range.Split("-");
        StartPoint = long.Parse(rangeSplit[0]);
        EndPoint = long.Parse(rangeSplit[1]);
    }

    public bool IsInRangeInclusive(long point)
    {
        return StartPoint <= point && EndPoint >= point;
    }

    public bool IsIntervalOverlap(Interval interval)
    {
        return IsInRangeInclusive(interval.StartPoint) || IsInRangeInclusive(interval.EndPoint);
    }

    public void Merge(Interval interval)
    {
        if (IsInRangeInclusive(interval.StartPoint) && IsInRangeInclusive(interval.EndPoint))
        {
            StartPoint = StartPoint <= interval.StartPoint ? StartPoint : interval.StartPoint;
            EndPoint = EndPoint >= interval.EndPoint ? EndPoint : interval.EndPoint;
            return;
        }
        if (IsInRangeInclusive(interval.StartPoint))
        {
            EndPoint = EndPoint >= interval.EndPoint ? EndPoint : interval.EndPoint;
            return;
        }
        if (IsInRangeInclusive(interval.EndPoint))
        {
            StartPoint = StartPoint <= interval.StartPoint ? StartPoint : interval.StartPoint;
        }
    }
}
