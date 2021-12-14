using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem542
    {
        public int[][] UpdateMatrix(int[][] mat)
        {
            var n = mat[0].Length;
            foreach (var t in mat)
            {
                for (var j = 0; j < n; j++)
                {
                    if (t[j] == 1)
                        t[j] = int.MaxValue;
                }
            }

            for (var i = 0; i < mat.Length; i++)
            {
                for (var j = 0; j < mat[i].Length; j++)
                {
                    if (mat[i][j] == 0)
                    {
                        SetPathLength(mat, i, j);
                    }
                }
            }

            return mat;
        }

        private static void SetPathLength(int[][] mat, int initialI, int initialJ)
        {
            var step = 0;

            var queue = new Queue<(int i, int j)>();
            queue.Enqueue((initialI, initialJ));

            while (queue.Any())
            {
                step++;

                var currentCount = queue.Count;

                while (currentCount > 0)
                {
                    currentCount--;

                    var (i, j) = queue.Dequeue();

                    for (short adjI = -1; adjI < 2; adjI++)
                    {
                        for (short adjJ = -1; adjJ < 2; adjJ++)
                        {
                            if (Math.Abs(adjI) == Math.Abs(adjJ)) continue;
                            if (i + adjI < 0 ||
                                i + adjI >= mat.Length ||
                                j + adjJ < 0 ||
                                j + adjJ >= mat[i + adjI].Length ||
                                mat[i + adjI][j + adjJ] <= step) continue;

                            var val1 = mat[i + adjI][j + adjJ];
                            if (val1 != 0)
                                mat[i + adjI][j + adjJ] = step;

                            queue.Enqueue((i + adjI, j + adjJ));
                        }
                    }
                }
            }
        }
    }
}