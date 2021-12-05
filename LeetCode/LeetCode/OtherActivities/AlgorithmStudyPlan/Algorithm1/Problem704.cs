namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem704
    {
        public int Search(int[] nums, int target)
        {
            int left = 0, index;
            var right = nums.Length - 1;
            while (true)
            {
                index = (right + left) / 2;
                if (nums[index] == target)
                    return index;

                if (left > right)
                    return -1;

                if (nums[index] > target)
                {
                    right = index - 1;
                    
                }
                else
                {
                    left = index + 1;
                }
            }
        }
    }
}