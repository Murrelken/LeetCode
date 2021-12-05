namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem704
    {
        public int Search(int[] nums, int target)
        {
            var index = nums.Length / 2;
            var left = 0;
            var right = nums.Length;
            var shouldSkipCheck = nums.Length == 2;
            while (true)
            {
                if (nums[index] == target)
                    return index;

                if (right - left < 2 && !shouldSkipCheck)
                    return -1;

                shouldSkipCheck = false;

                if (nums[index] > target)
                {
                    right = index;
                    index = (right + left) / 2;
                    if (index == right)
                        index--;
                    
                }
                else
                {
                    left = index;
                    index = (right + left) / 2;
                    if (index == left)
                        index++;
                }
            }
        }
    }
}