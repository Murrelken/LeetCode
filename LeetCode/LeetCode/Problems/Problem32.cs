using System;

namespace LeetCode.Problems
{
    public class Problem32
    {
        public int LongestValidParentheses(string s)
        {
            var res = 0;
            var dp = new int[s.Length];

            for (var i = 1; i < s.Length; i++)
            {
                if (s[i] == ')' && s[i - 1] == '(')
                    dp[i] = i < 2
                        ? 2
                        : dp[i - 2] + 2;

                var leftIndex = i - 1 - dp[i - 1];
                if (leftIndex >= 0 && s[i] == ')' && s[i - 1] == ')' && s[leftIndex] == '(')
                    dp[i] = dp[i - 1] + 2 + (leftIndex >= 1 ? dp[leftIndex - 1] : 0);

                res = Math.Max(res, dp[i]);
            }

            return res;
        }
    }
}