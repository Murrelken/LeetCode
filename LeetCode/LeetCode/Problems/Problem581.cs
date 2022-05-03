namespace LeetCode.Problems
{
    public class Problem581
    {
        public int FindUnsortedSubarray(int[] nums)
        {
            if (nums.Length <= 1)
                return 0;
            int leftIndex = -1, rightIndex = -1;

            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = nums.Length - 1; j > i; j--)
                {
                    if (nums[j] < nums[i])
                    {
                        leftIndex = i;
                        break;
                    }
                }

                if (leftIndex != -1)
                    break;
            }

            if (leftIndex == -1)
                return 0;

            for (var i = nums.Length - 1; i >= 0; i--)
            {
                for (var j = 0; j < i; j++)
                {
                    if (nums[j] > nums[i])
                    {
                        rightIndex = i;
                        break;
                    }
                }

                if (rightIndex != -1)
                    break;
            }

            return rightIndex - leftIndex + 1;
        }
    }
}