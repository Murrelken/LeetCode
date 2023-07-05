using System.Collections.Generic;

namespace LeetCode.Problems
{
    public class Problem1260
    {
        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            var vertLength = grid.Length;
            var horizontalLength = grid[0].Length;
            var max = vertLength * horizontalLength;

            if (k > max)
                k %= max;
            
            IList<IList<int>> res = new IList<int>[vertLength];
            for (var i = 0; i < grid.Length; i++)
                res[i] = new int[horizontalLength];

            for (int i = 0; i < max; i++)
            {
                var (x, y) = GetCorrectIndexes(i, horizontalLength);
                var (newX, newY) = GetCorrectIndexes(GetNextIndex(i, k, max), horizontalLength);
                res[newX][newY] = grid[x][y];
            }

            return res;
        }

        private (int x, int y) GetCorrectIndexes(int n, int horizontalLength)
            => (n / horizontalLength, n % horizontalLength);

        private int GetNextIndex(int i, int k, int maxLength)
            => i + k < maxLength
                ? i + k
                : i + k - maxLength;
    }
}