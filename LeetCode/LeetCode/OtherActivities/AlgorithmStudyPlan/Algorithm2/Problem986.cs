using System;
using System.Collections.Generic;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem986
    {
        public int[][] IntervalIntersection(int[][] f, int[][] s)
        {
            if (f.Length == 0 || s.Length == 0)
                return Array.Empty<int[]>();
            
            int i = 0, j = 0;
            var result = new List<int[]>();

            while (i < f.Length && j < s.Length)
            {
                var lo = Math.Max(f[i][0], s[j][0]);
                var hi = Math.Min(f[i][1], s[j][1]);
                if (lo <= hi)
                    result.Add(new []{lo, hi});

                if (f[i][1] < s[j][1])
                    i++;
                else
                    j++;
            }

            return result.ToArray();
        }
    }
}