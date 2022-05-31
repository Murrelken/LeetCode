namespace LeetCode.Problems
{
    public class Problem80
    {
        public int RemoveDuplicates(int[] nums)
        {
            int left = 0, right = 0, count = 0;
            int? currentNum = null;

            while (right <= nums.Length)
            {
                if (right < nums.Length && (currentNum == null || nums[right] == currentNum))
                {
                    count++;
                    currentNum = nums[right];
                    right++;
                }
                else
                {
                    switch (count)
                    {
                        case 0:
                            right++;
                            break;
                        case 1:
                            nums[left] = nums[right - 1];
                            left++;
                            break;
                        default:
                            for (var i = 0; i < 2; i++)
                            {
                                nums[left] = nums[right - 1];
                                left++;
                            }
                            break;
                    }

                    count = 0;
                    currentNum = null;
                }
            }

            return left;
        }
    }
}