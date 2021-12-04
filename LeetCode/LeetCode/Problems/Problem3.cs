using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem3
    {
        public int LengthOfLongestSubstring(string s)
        {
            var hash = new HashSet<char>();
            var begin = 0;
            var maxLength = 0;
            var end = 0;

            while (end < s.Length)
            {
                if (!hash.Contains(s[end]))
                {
                    hash.Add(s[end]);
                    end++;
                    maxLength = Math.Max(maxLength, end - begin);
                }
                else
                {
                    hash.Remove(s[begin]);
                    begin++;
                }
            }

            return maxLength;
        }
    }
}