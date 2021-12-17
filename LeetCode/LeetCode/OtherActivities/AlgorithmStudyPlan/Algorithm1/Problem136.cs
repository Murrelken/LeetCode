namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem136
    {
        public int SingleNumber(int[] nums)
        {
            for (var i = 1; i < nums.Length; i++)
            {
                nums[i] ^= nums[i - 1];
            }

            return nums[^1];
        }
    }
}