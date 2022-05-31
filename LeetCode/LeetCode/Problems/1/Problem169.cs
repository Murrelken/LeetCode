namespace LeetCode.Problems
{
    public class Problem169
    {
        public int MajorityElement(int[] nums)
        {
            var candidate = nums[0];
            var count = 1;

            for (var i = 1; i < nums.Length; i++)
            {
                if (nums[i] == candidate)
                    count++;
                else if (count == 1)
                    candidate = nums[i];
                else
                    count--;
            }

            return candidate;
        }
    }
}