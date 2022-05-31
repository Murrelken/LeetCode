using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem347
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            var dic = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (dic.ContainsKey(num))
                    dic[num]++;
                else
                    dic.Add(num, 1);
            }

            var res = dic
                .OrderByDescending(x => x.Value)
                .Take(k)
                .Select(x => x.Key)
                .ToArray();

            return res;
        }
    }
}