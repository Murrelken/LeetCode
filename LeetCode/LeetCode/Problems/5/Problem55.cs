using System;

public class Problem55
{
    public bool CanJump(int[] nums)
    {
        var consecutiveZeros = 0;
        for (int i = nums.Length - 2; i >= 0; i--)
            if (nums[i] == 0)
                consecutiveZeros++;
            else if (consecutiveZeros > 0)
                if (nums[i] >= consecutiveZeros + 1)
                    consecutiveZeros = 0;
                else
                    consecutiveZeros++;
        return consecutiveZeros == 0;
    }

    public bool CanJumpV2(int[] nums)
    {
        var reachable = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            if (i > reachable)
                return false;
            reachable = Math.Max(reachable, i + nums[i]);
        }
        return true;
    }
}