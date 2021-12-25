using System;
using System.Collections.Generic;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem200
    {
        public int NumIslands(char[][] grid)
        {
            var counted = new HashSet<(int i, int j)>();
            var maxCount = 0;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] != '1' || counted.Contains((i, j))) continue;
                    maxCount++;
                    Helper(grid, i, j, counted);
                }
            }

            return maxCount;
        }

        private static void Helper(char[][] grid, int i, int j, HashSet<(int i, int j)> counted)
        {
            if (counted.Contains((i, j))) return;
            counted.Add((i, j));

            for (short adjI = -1; adjI < 2; adjI++)
            {
                for (short adjJ = -1; adjJ < 2; adjJ++)
                {
                    if (Math.Abs(adjI) == Math.Abs(adjJ)) continue;
                    if (i + adjI < 0 ||
                        i + adjI >= grid.Length ||
                        j + adjJ < 0 ||
                        j + adjJ >= grid[i + adjI].Length) continue;

                    if (grid[i + adjI][j + adjJ] == '0') continue;
                    Helper(grid, i + adjI, j + adjJ, counted);
                }
            }
        }
    }
}