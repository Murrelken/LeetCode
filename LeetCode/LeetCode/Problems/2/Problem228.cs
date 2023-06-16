using System.Collections.Generic;

namespace LeetCode.Problems;

public class Problem228
{
    public IList<string> SummaryRanges(int[] nums)
    {
        var res = new List<string>();
        if (nums.Length == 0)
            return res;

        int first = nums[0], second;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1] + 1)
                continue;
            second = nums[i - 1];
            GetResultFormat(res, first, second);
            first = nums[i];
        }

        second = nums[^1];
        GetResultFormat(res, first, second);

        return res;
    }

    private static void GetResultFormat(List<string> res, int first, int second)
    {
        res.Add(first == second ? first.ToString() : $"{first}->{second}");
    }
}