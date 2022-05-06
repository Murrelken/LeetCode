using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCode.Problems
{
    public class Problem1209
    {
        public string RemoveDuplicates(string s, int k)
        {
            var sb = new StringBuilder(s);
            var startIndex = 0;

            while (true)
            {
                startIndex = Math.Max(startIndex, 0);
                var rerun = false;
                var currentChar = ' ';
                var currentCharCount = 0;
                for (var i = startIndex; i < sb.Length; i++)
                {
                    if (sb[i] == currentChar)
                        currentCharCount++;
                    else
                    {
                        currentChar = sb[i];
                        currentCharCount = 1;
                    }

                    if (currentCharCount == k)
                    {
                        rerun = true;
                        sb.Remove(i - k + 1, k);
                        startIndex = i - k * 2;
                        break;
                    }
                }
                if(!rerun) break;
            }

            return sb.ToString();
        }
    }
}