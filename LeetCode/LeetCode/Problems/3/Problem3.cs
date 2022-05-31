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

        public int LengthOfLongestSubstringSecond(string s)
        {
            var symbols = new Dictionary<char, int>();
            var maxLen = 0;
            var substrStart = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (symbols.ContainsKey(s[i]))
                {
                    var currentLen = i - substrStart;
                    maxLen = Math.Max(currentLen, maxLen);
                    if (symbols[s[i]] + 1 > substrStart) substrStart = symbols[s[i]] + 1;
                    symbols[s[i]] = i;
                }
                else symbols.Add(s[i], i);
            }

            return Math.Max(s.Length - substrStart, maxLen);
        }
    }
}