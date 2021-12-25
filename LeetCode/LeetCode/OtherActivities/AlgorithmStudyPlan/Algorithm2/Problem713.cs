namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem713
    {
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k <= 1)
                return 0;

            short left = 0, right = 0;
            int product = 1, count = 0;

            var len = nums.Length;
            while (right < len)
            {
                product *= nums[right];
                if (product < k)
                {
                    count += right - left + 1;
                    right++;
                }
                else
                {
                    while (product >= k)
                    {
                        product /= nums[left];
                        left++;
                    }

                    if (left > right)
                        right++;
                    else
                        product /= nums[right];
                }
            }

            return count;
        }
    }
}