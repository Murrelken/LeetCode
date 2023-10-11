using System;
using System.Linq;

public class Problem2251
{
    public int[] FullBloomFlowers(int[][] flowers, int[] people)
    {
        var starts = flowers
            .Select(x => x[0])
            .ToArray();
        Array.Sort(starts);
        var ends = flowers
            .Select(x => x[1])
            .ToArray();
        Array.Sort(ends);
        var newPeople = people
            .Select((x, i) => new { x, i })
            .OrderBy(x => x.x)
            .ToArray();
        var current = 0;
        var startsIndex = 0;
        var endsIndex = 0;

        foreach (var newPeep in newPeople)
        {
            var currentDay = newPeep.x;
            while (startsIndex < starts.Length && currentDay >= starts[startsIndex])
            {
                current++;
                startsIndex++;
            }
            while (endsIndex < ends.Length && currentDay > ends[endsIndex])
            {
                current--;
                endsIndex++;
            }

            people[newPeep.i] = current;
        }

        return people;
    }
}