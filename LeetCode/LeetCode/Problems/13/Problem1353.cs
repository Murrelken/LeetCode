using System;
using System.Collections.Generic;

namespace LeetCode.Problems;

public class Problem1353
{
    public int MaxEvents(int[][] events)
    {
        Array.Sort(events, (a, b) =>
            a[0] == b[0]
                ? a[1].CompareTo(b[1])
                : a[0].CompareTo(b[0]));

        var res = 0;
        var i = 0;
        var queue = new PriorityQueue<int, int>();

        for (var day = 1; day <= 100000; day++)
        {
            while (i < events.Length && events[i][0] == day)
            {
                queue.Enqueue(events[i][1], events[i][1]);
                i++;
            }

            while (queue.Count > 0 && queue.Peek() < day)
                queue.Dequeue();

            if (queue.TryDequeue(out _, out _))
                res++;

            if (queue.Count == 0 && i == events.Length)
                break;
        }

        return res;
    }
}