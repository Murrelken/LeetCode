using System;
using System.Linq;
using Enumerable = System.Linq.Enumerable;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem557
    {
        public string ReverseWords(string s)
        {
            int left, right;
            left = right = 0;
            var stringArray = s.ToArray();

            while (right <= s.Length)
            {
                if (right == s.Length || s[right] == ' ')
                {
                    Array.Reverse(stringArray, left, right - left);
                    left = right + 1;
                }

                right++;
            }
            
            return new string(stringArray);
        }
    }
}