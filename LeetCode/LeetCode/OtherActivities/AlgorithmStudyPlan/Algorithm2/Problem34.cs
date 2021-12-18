namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem34
    {
        public int[] SearchRange(int[] nums, int target)
        {
            var result = new int[2];

            var left = 0;
            var right = nums.Length - 1;

            while (left < right)
            {
                var mid = (right + left) / 2;

                if (nums[mid] >= target)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            if (nums.Length > 0 && nums[left] == target)
                result[0] = left;
            else
            {
                result[0] = -1;
                result[1] = -1;
                return result;
            }

            left = 0;
            right = nums.Length - 1;
            while (left < right)
            {
                var mid = (right + left) / 2;

                if (nums[mid] <= target)
                {
                    if (left == mid)
                    {
                        if (nums[mid + 1] == target)
                            left++;

                        break;
                    }

                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }

            result[1] = left;

            return result;
        }
    }
}