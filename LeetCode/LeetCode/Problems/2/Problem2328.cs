using System.Linq;

namespace LeetCode.Problems;

public class Problem2328
{
    private (int, int)[] _paths = { (-1, 0), (0, -1), (0, 1), (1, 0) };
    private int[][] _grid;
    private int[][] _dp;
    private int _m;
    private int _n;
    private const int Mod = 1_000_000_007;

    public int CountPaths(int[][] grid)
    {
        _grid = grid;
        _m = grid.Length;
        _n = grid[0].Length;
        _dp = new int[_m][];
        for (var i = 0; i < _m; i++)
            _dp[i] = new int[_n];

        var res = 0;
        for (var i = 0; i < _m; i++)
        for (var j = 0; j < _n; j++)
            res = (res + DFS(i, j)) % Mod;

        return res;
    }

    private int DFS(int i, int j)
    {
        if (_dp[i][j] != 0)
            return _dp[i][j];

        var count = 1;
        foreach (var (item1, item2) in _paths)
        {
            var newI = i + item1;
            var newJ = j + item2;

            if (newI < 0 || newI >= _m || newJ < 0 || newJ >= _n || _grid[newI][newJ] >= _grid[i][j])
                continue;

            count = (count + DFS(newI, newJ)) % Mod;
        }

        return _dp[i][j] = count;
    }
}