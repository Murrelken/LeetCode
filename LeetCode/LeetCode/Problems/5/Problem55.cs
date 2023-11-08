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
}