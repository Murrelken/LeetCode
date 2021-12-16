using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem120
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            for (var i = 1; i < triangle.Count; i++)
            {
                for (var j = 0; j < i + 1; j++)
                {
                    if (j == 0)
                    {
                        triangle[i][j] += triangle[i - 1][j];
                    }
                    else if (j == i)
                    {
                        triangle[i][j] += triangle[i - 1][j - 1];
                    }
                    else
                    {
                        triangle[i][j] = Math.Min(triangle[i][j] + triangle[i - 1][j - 1], triangle[i][j] + triangle[i - 1][j]);
                    }
                }
            }

            return triangle.Last().Min();
        }
    }
}