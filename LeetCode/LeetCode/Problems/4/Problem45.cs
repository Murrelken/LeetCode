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

    public int JumpV2(int[] nums)
    {
        var n = nums.Length;
        for (var i = 1; i < n; i++)
        {
            nums[i] = Math.Max(nums[i] + i, nums[i - 1]);
        }

        var ind = 0;
        var res = 0;

        while (ind < n - 1)
        {
            res++;
            ind = nums[ind];
        }

        return res;
    }
}