namespace LeetCode.Problems
{
    public class Problem1480
    {
        public int[] RunningSum(int[] nums)
        {
            for (var i = 1; i < nums.Length; i++)
                nums[i] += nums[i - 1];

            return nums;
        }
    }
}