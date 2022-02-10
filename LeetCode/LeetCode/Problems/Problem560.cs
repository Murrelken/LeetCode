using System.Collections.Generic;

namespace LeetCode.Problems
{
    public class Problem560
    {
        public int SubarraySum(int[] nums, int k)
        {
            var dic = new Dictionary<int, int> { { 0, 1 } };
            int sum = 0, count = 0;

            foreach (var t in nums)
            {
                sum += t;
                if (dic.ContainsKey(sum - k))
                    count += dic[sum - k];

                if (dic.ContainsKey(sum))
                    dic[sum]++;
                else
                    dic.Add(sum, 1);
            }

            return count;
        }

        public int SubArraySumEasy(int[] nums, int k)
        {
            var res = 0;
            var sums = new int[nums.Length];
            sums[0] = nums[0];
            if (nums[0] == k)
                res++;

            for (var i = 1; i < nums.Length; i++)
            {
                sums[i] = sums[i - 1] + nums[i];
                if (sums[i] == k)
                    res++;
            }

            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (sums[j] - sums[i] == k)
                        res++;
                }
            }

            return res;
        }
    }
}