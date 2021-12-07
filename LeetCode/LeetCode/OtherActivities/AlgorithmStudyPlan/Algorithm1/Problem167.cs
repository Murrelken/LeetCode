namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem167
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            short left = 0, right = (short) (numbers.Length - 1);

            while (numbers[left] + numbers[right] != target)
            {
                if (numbers[left] + numbers[right] > target)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
            
            return new[] { left + 1, right + 1 };
        }
    }
}