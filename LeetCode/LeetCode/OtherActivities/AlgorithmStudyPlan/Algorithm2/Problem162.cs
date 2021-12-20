namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem162
    {
        public int FindPeakElement(int[] nums)
        {
            var n = nums.Length;
            if (n == 1) return 0;
            if (nums[0] > nums[1]) return 0;
            if (nums[n - 2] < nums[n - 1]) return n - 1;

            var left = 0;
            var right = n - 1;

            while (left < right)
            {
                var mid = (left + right) / 2;

                if (nums[mid - 1] < nums[mid] && nums[mid] > nums[mid + 1])
                {
                    return mid;
                }

                if (nums[mid - 1] > nums[mid])
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }
    }
}