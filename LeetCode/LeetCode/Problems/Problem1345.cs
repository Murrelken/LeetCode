using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem1345
    {
        public int MinJumps(int[] arr)
        {
            var dic = new Dictionary<int, List<int>>();
            var visited = new HashSet<int>();
            var visitedNumbers = new HashSet<int>();
            var step = -1;
            var found = false;

            for (var i = 0; i < arr.Length; i++)
            {
                if (dic.ContainsKey(arr[i]))
                    dic[arr[i]].Add(i);
                else
                    dic.Add(arr[i], new List<int> { i });
            }

            var queue = new Queue<int>();
            queue.Enqueue(0);
            visited.Add(0);

            while (!found)
            {
                step++;
                var queueCount = queue.Count;

                while (queueCount > 0)
                {
                    queueCount--;
                    var index = queue.Dequeue();
                    if (index < 0 || index >= arr.Length)
                        continue;
                    if (index == arr.Length - 1)
                    {
                        found = true;
                        break;
                    }

                    if (!visitedNumbers.Contains(arr[index]))
                    {
                        foreach (var i in dic[arr[index]])
                        {
                            if (!visited.Contains(i))
                            {
                                queue.Enqueue(i);
                                visited.Add(i);
                            }
                        }

                        visitedNumbers.Add(arr[index]);
                    }

                    if (!visited.Contains(index - 1))
                    {
                        queue.Enqueue(index - 1);
                        visited.Add(index - 1);
                    }

                    if (!visited.Contains(index + 1))
                    {
                        queue.Enqueue(index + 1);
                        visited.Add(index + 1);
                    }
                }
            }

            return step;
        }
    }
}