namespace LeetCode.Problems
{
    public class Problem665
    {
        public bool CheckPossibility(int[] nums)
        {
            var found = false;
            for (var i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] <= nums[i + 1]) continue;
                if ((i != 0 && nums[i - 1] > nums[i + 1] && i != nums.Length - 2 && nums[i + 2] < nums[i]) ||
                    found)
                    return false;
                found = true;
            }

            return true;
        }
    }
}