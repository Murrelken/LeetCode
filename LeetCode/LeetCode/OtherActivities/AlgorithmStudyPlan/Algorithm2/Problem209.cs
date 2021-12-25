using System;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem209
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            if (target == 1)
                return 1;

            int left = 0, right = 0;
            int sum = 0, minLen = int.MaxValue;

            var len = nums.Length;
            while (right < len)
            {
                sum += nums[right];

                if (sum >= target)
                {
                    while (left < len && sum - nums[left] >= target)
                    {
                        sum -= nums[left];
                        left++;
                    }

                    minLen = Math.Min(minLen, right - left + 1);
                    right++;
                }
                else
                {
                    right++;
                }
            }

            return minLen == int.MaxValue ? 0 : minLen;
        }
    }
}