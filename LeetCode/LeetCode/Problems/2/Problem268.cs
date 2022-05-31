using System.Collections.Generic;

namespace LeetCode.Problems
{
    public class Problem268
    {
        public int MissingNumber(int[] nums)
        {
            var hash = new HashSet<int>(nums);

            for (int i = 0; i <= nums.Length; i++)
                if (!hash.Contains(i))
                    return i;

            return -1;
        }
    }
}