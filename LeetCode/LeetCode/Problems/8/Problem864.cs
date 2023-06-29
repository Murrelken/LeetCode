using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems;

public class Problem864
{
    public int ShortestPathAllKeys(string[] grid)
    {
        var steps = 0;
        
        var height = grid.Length;
        var width = grid[0].Length;

        var fullMemo = new Dictionary<string, int>[height][];
        for (var i = 0; i < fullMemo.Length; i++)
        {
            fullMemo[i] = new Dictionary<string,int>[width];
            for (var j = 0; j < fullMemo[i].Length; j++)
                fullMemo[i][j] = new Dictionary<string, int>();
        }

        var indexByChar = new Dictionary<char, int>()
        {
            { 'a', 0 },
            { 'b', 1 },
            { 'c', 2 },
            { 'd', 3 },
            { 'e', 4 },
            { 'f', 5 }
        };

        var possibleSteps = new[] { (-1, 0), (0, -1), (1, 0), (0, 1) };

        var totalKeys = 0;

        var queue = new Queue<(int h, int w, HashSet<char>, bool[][])>();

        var visitedInitial = new bool[height][];
        for (var i = 0; i < visitedInitial.Length; i++)
            visitedInitial[i] = new bool[width];

        for (var i = 0; i < height; i++)
        for (var j = 0; j < width; j++)
            if (char.IsLetter(grid[i][j]))
                totalKeys++;
            else if (grid[i][j] == '@')
                queue.Enqueue((i, j, new HashSet<char>(), visitedInitial));

        totalKeys /= 2;

        while (queue.Any())
        {
            var count = queue.Count;

            while (count > 0)
            {
                count--;
                var (h, w, keys, visited) = queue.Dequeue();

                var keyForMemoArr = new char[6];
                foreach (var key in keys)
                {
                    keyForMemoArr[indexByChar[key]] = key;
                }

                var keyForMemo = new string(keyForMemoArr);
                
                if(visited[h][w] || fullMemo[h][w].TryGetValue(keyForMemo, out var value) && value <= steps)
                    continue;

                if (!fullMemo[h][w].TryAdd(keyForMemo, steps))
                    fullMemo[h][w][keyForMemo] = steps;

                if (char.IsLetter(grid[h][w]) && char.IsLower(grid[h][w]))
                {
                    keys = new HashSet<char>(keys);
                    keys.Add(grid[h][w]);
                    if(keys.Count == totalKeys)
                        return steps;
                    visited = new bool[height][];
                    for (var i = 0; i < visited.Length; i++)
                        visited[i] = new bool[width];
                }

                visited[h][w] = true;
                
                foreach (var (item1, item2) in possibleSteps)
                {
                    var newH = h + item1;
                    var newW = w + item2;
                    if (newH < 0 || newH >= height || newW < 0 || newW >= width ||
                        visited[newH][newW] || grid[newH][newW] == '#' ||
                        char.IsLetter(grid[newH][newW]) &&
                        char.IsUpper(grid[newH][newW]) &&
                        !keys.Contains(char.ToLower(grid[newH][newW])))
                        continue;
                    
                    queue.Enqueue((newH, newW, keys, visited));
                }
            }

            steps++;
        }

        return -1;
    }
}