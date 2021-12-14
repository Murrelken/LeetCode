using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem542
    {
        public int[][] UpdateMatrix(int[][] mat)
        {
            for (byte i = 0; i < mat.Length; i++)
            {
                for (byte j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == 1)
                    {
                        mat[i][j] = GetPathLength(mat, i, j);
                    }
                        
                }
            }

            return mat;
        }

        private static int GetPathLength(int[][] mat, int initialI, int initialJ)
        {
            var step = 0;
            var alreadyVisited = new HashSet<(int i, int j)>();

            var newList = new List<(int i, int j)> { (initialI, initialJ) };

            while (newList.Count > 0)
            {
                step++;
                var tempList = newList
                    .Except(alreadyVisited)
                    .ToList();

                newList.Clear();

                foreach (var (i, j) in tempList)
                {
                    alreadyVisited.Add((i, j));

                    for (short adjI = -1; adjI < 2; adjI++)
                    {
                        for (short adjJ = -1; adjJ < 2; adjJ++)
                        {
                            if (Math.Abs(adjI) == Math.Abs(adjJ)) continue;
                            if (i + adjI < 0 ||
                                i + adjI >= mat.Length ||
                                j + adjJ < 0 ||
                                j + adjJ >= mat[i + adjI].Length) continue;

                            if (mat[i + adjI][j + adjJ] == 0) return step;
                            newList.Add((i + adjI, j + adjJ));
                        }
                    }
                }
            }

            return step;
        }
    }
}