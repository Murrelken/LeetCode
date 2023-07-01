using System.Collections.Generic;

namespace LeetCode.Problems;

public class Problem373
{
    public IList<IList<int>> KSmallestPairs(int[] nums1, int[] nums2, int k)
    {
        var n = nums1.Length;
        var m = nums2.Length;

        var priorityQueue = new PriorityQueue<(int, int), int>();
        priorityQueue.Enqueue((0, 0), nums1[0] + nums2[0]);

        var visited = new HashSet<(int, int)>();
        var retList = new List<IList<int>>();

        while (priorityQueue.Count > 0 && retList.Count < k){
            var (x, y) = priorityQueue.Dequeue();

            retList.Add(new List<int>{nums1[x], nums2[y]});
            visited.Add((x, y));

            if (x + 1 < n && y < m && !visited.Contains((x + 1, y))){
                priorityQueue.Enqueue((x + 1, y), nums1[x + 1] + nums2[y]);
                visited.Add((x + 1, y));
            }   

            if (x < n && y + 1 < m && !visited.Contains((x, y + 1))){
                priorityQueue.Enqueue((x, y + 1), nums1[x] + nums2[y + 1]);
                visited.Add((x, y + 1));
            } 
        }

        return retList;
    }
}