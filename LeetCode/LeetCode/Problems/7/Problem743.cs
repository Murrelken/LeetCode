using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem743
    {
        Dictionary<int, List<(int, int)>> dic = new();

        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            // Build the adjacency list
            foreach (var time in times)
            {
                var source = time[0];
                var dest = time[1];
                var travelTime = time[2];

                dic.TryAdd(source, new List<(int, int)>());
                dic[source].Add((travelTime, dest));
            }

            // Sort the edges connecting to every node
            foreach (var (key, value) in dic)
            {
                dic[key] = value.OrderBy(x => x.Item1).ToList();
            }

            var signalReceivedAt = new int[n + 1];
            Array.Fill(signalReceivedAt, int.MaxValue);

            DFS(signalReceivedAt, k, 0);

            var answer = int.MinValue;
            for (var node = 1; node <= n; node++)
            {
                answer = Math.Max(answer, signalReceivedAt[node]);
            }

            // Integer.MAX_VALUE signifies atleat one node is unreachable
            return answer == int.MaxValue ? -1 : answer;
        }


        private void DFS(int[] signalReceivedAt, int currNode, int currTime)
        {
            // If the current time is greater than or equal to the fastest signal received
            // Then no need to iterate over adjacent nodes
            if (currTime >= signalReceivedAt[currNode])
            {
                return;
            }

            // Fastest signal time for currNode so far
            signalReceivedAt[currNode] = currTime;

            if (!dic.ContainsKey(currNode))
            {
                return;
            }

            // Broadcast the signal to adjacent nodes
            foreach (var (travelTime, neighborNode) in dic[currNode])
            {
                // currTime + time : time when signal reaches neighborNode
                DFS(signalReceivedAt, neighborNode, currTime + travelTime);
            }
        }
    }
}