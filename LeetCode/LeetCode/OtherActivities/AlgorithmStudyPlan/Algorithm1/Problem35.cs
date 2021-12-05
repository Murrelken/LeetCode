namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem35
    {
        public int SearchInsert(int[] nums, int target)
        {
            int left = 0, index;
            var right = nums.Length - 1;
            while (true)
            {
                index = (right + left) / 2;
                if (nums[index] == target)
                    return index;

                if (nums[index] > target)
                {
                    right = index - 1;
                    if (left > right)
                        return index;
                }
                else
                {
                    left = index + 1;
                    if (left > right)
                        return index + 1;
                }
            }
        }
    }
}