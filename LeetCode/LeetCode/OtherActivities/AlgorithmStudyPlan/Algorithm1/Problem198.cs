using System;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem198
    {
        public int Rob(int[] nums)
        {
            if (nums.Length == 1)
                return nums[0];

            for (var i = 1; i < nums.Length; i++)
            {
                var minusTwo = i < 2 ? 0 : nums[i - 2];
                var minusThree = i < 3 ? 0 : nums[i - 3];
                nums[i] = Math.Max(nums[i] + minusTwo, nums[i] + minusThree);
            }

            return nums.Max();
        }
    }
}