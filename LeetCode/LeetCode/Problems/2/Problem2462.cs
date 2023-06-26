using System.Collections.Generic;

namespace LeetCode.Problems;

public class Problem2462
{
    public long TotalCost(int[] costs, int k, int candidates)
    {
        var cost = 0L;
        int left = 0, right = costs.Length - 1;
        var sorted = new List<int>();
        var indexesByValue = new Dictionary<int, List<int>>();
        for (var i = 0; i < candidates; i++)
        {
            var index = SearchInsert(sorted, costs[i]);
            sorted.Insert(index, costs[i]);
            if(!indexesByValue.TryAdd(costs[i], new List<int>{i}))
                indexesByValue[costs[i]].Insert(SearchInsert(indexesByValue[costs[i]], i), i);
            left++;
        }

        for (var i = costs.Length - 1; i >= costs.Length - candidates && right > left; i--)
        {
            var index = SearchInsert(sorted, costs[i]);
            sorted.Insert(index, costs[i]);
            if(!indexesByValue.TryAdd(costs[i], new List<int>{i}))
                indexesByValue[costs[i]].Insert(SearchInsert(indexesByValue[costs[i]], i), i);
            right--;
        }

        while (k > 0)
        {
            var value = sorted[0];
            var previousIndex = indexesByValue[sorted[0]][0];
            indexesByValue[value].RemoveAt(0);
                
            if (indexesByValue[value].Count == 0)
                indexesByValue.Remove(value);

            sorted.RemoveAt(0);

            cost += value;

            if (right >= left)
            {
                if (previousIndex < left)
                {
                    var index = SearchInsert(sorted, costs[left]);
                    sorted.Insert(index, costs[left]);
                    if(!indexesByValue.TryAdd(costs[left], new List<int>{left}))
                        indexesByValue[costs[left]].Insert(SearchInsert(indexesByValue[costs[left]], left), left);
                    left++;
                }
                else
                {
                    var index = SearchInsert(sorted, costs[right]);
                    sorted.Insert(index, costs[right]);
                    if(!indexesByValue.TryAdd(costs[right], new List<int>{right}))
                        indexesByValue[costs[right]].Insert(SearchInsert(indexesByValue[costs[right]], right), right);
                    right--;
                }
            }

            k--;
        }

        return cost;
    }

    public int SearchInsert(List<int> nums, int target)
    {
        if (nums.Count == 0)
            return 0;
            
        int left = 0, index;
        var right = nums.Count - 1;
        while (true)
        {
            index = (right + left) / 2;
            if (nums[index] == target)
                return index;

            if (nums[index] > target)
            {
                right = index - 1;
                if (left > right)
                    return index;
            }
            else
            {
                left = index + 1;
                if (left > right)
                    return index + 1;
            }
        }
    }
}