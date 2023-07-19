namespace LeetCode.Problems._27;

public class Problem2778
{
    public int SumOfSquares(int[] nums)
    {
        var res = 0;
        for (var i = 0; i < nums.Length / 2; i++)
            if (nums.Length % (i + 1) == 0)
                res += nums[i] * nums[i];
        return res + nums[^1] * nums[^1];
    }
}