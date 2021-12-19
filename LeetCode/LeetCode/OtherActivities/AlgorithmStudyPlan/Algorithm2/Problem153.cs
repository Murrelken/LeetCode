using System;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem153
    {
        public int FindMin(int[] nums)
        {
            int left = 0, min = nums[0];
            var right = nums.Length - 1;
            while (left <= right)
            {
                var mid = (right + left) / 2;
                if (nums[mid] < min)
                    min = nums[mid];

                if (nums[left] <= nums[mid])
                {
                    if (nums[mid] < nums[right])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else
                {
                    right = mid - 1;
                }
            }

            return min;
        }
    }
}