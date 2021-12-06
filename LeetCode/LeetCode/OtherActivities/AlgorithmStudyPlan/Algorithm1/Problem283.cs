namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem283
    {
        public void MoveZeroes(int[] nums)
        {
            var insertIndex = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    (nums[insertIndex], nums[i]) = (nums[i], nums[insertIndex]);
                    insertIndex++;
                }
            }
        }
    }
}