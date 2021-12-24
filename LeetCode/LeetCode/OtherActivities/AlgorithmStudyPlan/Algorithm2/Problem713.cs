namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem713
    {
        public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k <= 1)
                return 0;

            short begin = 0, end = 0;
            int product = 1, count = 0;

            var len = nums.Length;
            while (end < len)
            {
                product *= nums[end];
                if (product < k)
                {
                    count += end - begin + 1;
                    end++;
                }
                else
                {
                    while (product >= k)
                    {
                        product /= nums[begin];
                        begin++;
                    }

                    if (begin > end)
                        end++;
                    else
                        product /= nums[end];
                }
            }

            return count;
        }
    }
}