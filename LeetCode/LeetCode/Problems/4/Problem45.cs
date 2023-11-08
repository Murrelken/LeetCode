using System;

public class Problem45
{
    public int Jump(int[] nums)
    {
        var n = nums.Length;
        var dp = new int[n];
        Array.Fill(dp, int.MaxValue);
        dp[0] = 0;
        for (var i = 0; i < n; i++)
        {
            var currentStep = dp[i] + 1;
            for (var j = Math.Min(n - 1, i + nums[i]); j > i; j--)
            {
                if (dp[j] <= currentStep)
                {
                    break;
                }
                else
                {
                    dp[j] = currentStep;
                }
            }
        }

        return dp[n - 1];
    }
}