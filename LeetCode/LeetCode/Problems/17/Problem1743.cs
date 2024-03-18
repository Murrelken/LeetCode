using System.Collections.Generic;
using System.Linq;

public class Problem1743
{
    public int[] RestoreArray(int[][] adjacentPairs)
    {
        var uniqueItems = new Dictionary<int, (int, int?)>();
        var itemsWithOnlyOnePair = new HashSet<int>();

        foreach (var pair in adjacentPairs)
        {
            if (uniqueItems.TryAdd(pair[0], (pair[1], null)))
            {
                itemsWithOnlyOnePair.Add(pair[0]);
            }
            else
            {
                uniqueItems[pair[0]] = (uniqueItems[pair[0]].Item1, pair[1]);
                itemsWithOnlyOnePair.Remove(pair[0]);
            }

            if (uniqueItems.TryAdd(pair[1], (pair[0], null)))
            {
                itemsWithOnlyOnePair.Add(pair[1]);
            }
            else
            {
                uniqueItems[pair[1]] = (uniqueItems[pair[1]].Item1, pair[0]);
                itemsWithOnlyOnePair.Remove(pair[1]);
            }
        }

        var result = new int[uniqueItems.Count];
        var current = itemsWithOnlyOnePair.First();
        for (var i = 0; i < result.Length; i++)
        {
            result[i] = current;
            var currentPairs = uniqueItems[current];
            current = currentPairs.Item2 == null
                ? currentPairs.Item1
                : currentPairs.Item1 == result[i - 1]
                    ? currentPairs.Item2.Value
                    : currentPairs.Item1;
        }

        return result;
    }
}