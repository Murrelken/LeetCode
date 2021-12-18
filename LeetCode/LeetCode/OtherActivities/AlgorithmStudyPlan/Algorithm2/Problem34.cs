namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem34
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var n = nums.Length;

            var left = 0;
            var right = n;

            while (left < right)
            {
                var mid = left + (right - left) / 2;

                if (nums[mid] >= target)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            var rangeLeft = left;
            if (rangeLeft == n || nums[left] != target)
            {
                return new[] { -1, -1 };
            }

            left = rangeLeft;
            right = n;

            while (left < right)
            {
                var mid = left + (right - left) / 2;

                if (nums[mid] > target)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return new[] { rangeLeft, left - 1 };
        }
    }
}