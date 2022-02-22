using System;

namespace LeetCode.Problems
{
    public class Problem171
    {
        public int TitleToNumber(string columnTitle)
        {
            var res = 0;

            for (int i = columnTitle.Length - 1; i > -1; i--)
            {
                res += (columnTitle[i] - 'A' + 1) * (int)Math.Pow(26, columnTitle.Length - 1 - i);
            }

            return res;
        }
    }
}