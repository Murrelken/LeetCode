using System;
using System.Collections.Generic;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem695
    {
        public int MaxAreaOfIsland(int[][] grid)
        {
            var counted = new HashSet<(int i, int j)>();
            var maxCount = 0;
            
            for (byte i = 0; i < grid.Length; i++)
            {
                for (byte j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        maxCount = Math.Max(maxCount, GetCount(grid, i, j, counted));
                    }
                        
                }
            }

            return maxCount;
        }

        private static short GetCount(int[][] grid, byte i, byte j, HashSet<(int i, int j)> counted)
        {
            if (counted.Contains((i, j))) return 0;
            counted.Add((i, j));

            short count = 1;
            
            for (short adjI = -1; adjI < 2; adjI++)
            {
                for (short adjJ = -1; adjJ < 2; adjJ++)
                {
                    if (Math.Abs(adjI) == Math.Abs(adjJ)) continue;
                    if (i + adjI < 0 ||
                        i + adjI >= grid.Length ||
                        j + adjJ < 0 ||
                        j + adjJ >= grid[i + adjI].Length) continue;

                    if (grid[i + adjI][j + adjJ] == 0) continue;
                    count += GetCount(grid, (byte)(i + adjI), (byte)(j + adjJ), counted);
                }
            }

            return count;
        }
    }
}