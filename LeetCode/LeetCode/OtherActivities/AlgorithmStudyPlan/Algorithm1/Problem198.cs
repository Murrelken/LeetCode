using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem198
    {
        public int Rob(int[] nums)
        {
            var resultCombinations = new List<int>();

            Helper(0, 0, resultCombinations, nums);

            return resultCombinations.Max();
        }

        private void Helper(int i, int sum, List<int> res, int[] nums)
        {
            if (i >= nums.Length)
                res.Add(sum);
            else
                for (var j = i; j <= nums.Length - 1; j++)
                {
                    sum += nums[j];

                    Helper(j + 2, sum, res, nums);

                    sum -= nums[j];
                }
        }
    }
}