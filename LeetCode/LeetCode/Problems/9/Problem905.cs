namespace LeetCode.Problems
{
    public class Problem905
    {
        public int[] SortArrayByParity(int[] nums)
        {
            var res = new int[nums.Length];
            int left = 0, right = nums.Length - 1;
            
            foreach (var num in nums)
            {
                if (num % 2 == 0)
                {
                    res[left] = num;
                    left++;
                }
                else
                {
                    res[right] = num;
                    right--;
                }
            }

            return res;
        }
    }
}