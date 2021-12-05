namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem704
    {
        public int Search(int[] nums, int target)
        {
            var index = nums.Length / 2;
            var remainingArrayLength = nums.Length / 2;
            while (true)
            {
                if (nums[index] == target)
                    return index;

                if (remainingArrayLength == 0)
                    return -1;

                if (nums[index] > target)
                {
                    index -= remainingArrayLength == 1 ? 1 : remainingArrayLength / 2;
                }
                else
                {
                    index += remainingArrayLength == 1 ? 1 : remainingArrayLength / 2;
                }

                remainingArrayLength /= 2;
            }
        }
    }
}