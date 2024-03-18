using System.Collections.Generic;

namespace LeetCode.Problems._23;

public class Problem2352
{
    public int EqualPairs(int[][] grid)
    {
        var res = 0;
        var rows = new Dictionary<string, int>();

        foreach (var t in grid)
        {
            var row = string.Join(',', t);
            if(!rows.TryAdd(row, 1))
                rows[row]++;
        }

        var column = new int[grid.Length];
        for (var col = 0; col < grid.Length; col++)
        {
            for (var i = 0; i < grid.Length; i++)
                column[i] = grid[i][col];

            var strCol = string.Join(',', column);
            if (rows.TryGetValue(strCol, out var rowsCount))
                res += rowsCount;
        }

        return res;
    }
}