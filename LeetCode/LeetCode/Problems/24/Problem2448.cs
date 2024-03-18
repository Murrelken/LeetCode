using System.Linq;

namespace LeetCode.Problems._24;

public class Problem2448
{//1907611126748
    public long MinCost(int[] nums, int[] cost)
    {
        var mod = 1000000007;
        // var numsByCost = new Dictionary<int, List<int>>();
        //
        // for (var i = 0; i < nums.Length; i++)
        //     if (!numsByCost.TryAdd(cost[i], new List<int> { nums[i] }))
        //         numsByCost[cost[i]].Add(nums[i]);

        // (int cost, int value)[] sortedTargets = numsByCost
        //     .SelectMany(x => x.Value.Count % 2 == 1
        //         ? new (int, int)[] { (x.Key, x.Value[x.Value.Count / 2]) }
        //         : new (int, int)[] { (x.Key, x.Value[x.Value.Count / 2]), (x.Key, x.Value[x.Value.Count / 2 - 1]) })
        //     .OrderByDescending(x=>x.Item1)
        //     .ToArray();

        // var sorted = new List<(int cost, int value)>();
        //
        // foreach (var (key, value) in numsByCost)
        // {
        //     if(value.Count % 2 == 1)
        //         sorted.Add((key, value[value.Count / 2]));
        //     else
        //     {
        //         sorted.Add((key, value[value.Count / 2]));
        //         sorted.Add((key, value[value.Count / 2 - 1]));
        //     }
        // }
        
        (int cost, int value)[] fullSorted = nums
            .Select((x, i) => (cost[i], x))
            .OrderByDescending(x => x.Item1)
            .ToArray();

        var minCost = long.MaxValue % mod;
        var countOfModInTheMinCost = long.MaxValue / mod;

        for (var targetI = 0; targetI < fullSorted.Length; targetI++)
        {
            var target = fullSorted[targetI].value;
            long tempSum = 0;
            long tempCountOfMods = 0;
            for (var i = 0; i < fullSorted.Length; i++)
            {
                var currentVal = fullSorted[i].value;

                if (currentVal == target)
                    continue;

                long diff = currentVal > target ? currentVal - target : target - currentVal;

                long multiplier = fullSorted[i].cost;
                
                tempSum += diff * multiplier;
                tempCountOfMods += tempSum / mod;
                tempSum %= mod;

                if (tempCountOfMods > countOfModInTheMinCost ||
                    tempCountOfMods == countOfModInTheMinCost && tempSum >= minCost)
                    break;
            }

            if (tempCountOfMods < countOfModInTheMinCost ||
                tempCountOfMods == countOfModInTheMinCost && tempSum < minCost)
            {
                minCost = tempSum;
                countOfModInTheMinCost = tempCountOfMods;
            }
        }

        return minCost + mod * countOfModInTheMinCost;
    }
}