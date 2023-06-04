using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems;

//There is another implementation in the Algorithm2 folder
public class Problem547
{
    public int FindCircleNum(int[][] isConnected)
    {
        var visited = new HashSet<int>();
        var result = 0;

        for (var i = 0; i < isConnected.Length; i++)
        {
            if (visited.Contains(i))
                continue;

            var queue = new Queue<int>();
            queue.Enqueue(i);

            while (queue.Any())
            {
                var currentI = queue.Dequeue();
                visited.Add(currentI);
                var listOfConnected = isConnected[currentI];

                for (var j = 0; j < isConnected.Length; j++)
                {
                    var connected = listOfConnected[j];
                    if (connected == 0 || visited.Contains(j))
                        continue;

                    queue.Enqueue(j);
                }
            }

            result++;
        }

        return result;
    }
}