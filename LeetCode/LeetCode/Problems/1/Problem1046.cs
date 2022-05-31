using System;
using System.Linq;
using LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1;

namespace LeetCode.Problems
{
    public class Problem1046
    {
        public int LastStoneWeight(int[] stones)
        {
            var searcher = new Problem35();
            Array.Sort(stones);
            var list = stones
                .ToList();

            for (var i = stones.Length - 1; i >= 1; i--)
            {
                var f = list[i];
                var s = list[i - 1];
                var mod = Math.Abs(f - s);
                list[i] = int.MaxValue;
                list[i - 1] = int.MaxValue;

                if (mod == 0)
                {
                    i--;
                    if(i == 0)
                        return 0;
                    continue;
                }
                
                list.Insert(searcher.SearchInsert(list.ToArray(), mod), mod);
            }

            return list[0];
        }
    }
}