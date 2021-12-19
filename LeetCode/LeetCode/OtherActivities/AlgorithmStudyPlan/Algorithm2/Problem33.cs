namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem33
    {
        public int Search(int[] nums, int target)
        {
            int left = 0, mid;
            var right = nums.Length - 1;
            while (true)
            {
                mid = (right + left) / 2;
                if (nums[mid] == target)
                    return mid;

                if (left > right)
                    return -1;

                if (nums[left] <= nums[mid])
                {
                    if (nums[left] <= target && target <= nums[mid])
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
                    if (nums[mid] <= target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
            }
        }
    }
}