using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem1048
    {
        public int LongestStrChain(string[] words)
        {
            var sorted = words
                .GroupBy(x => x.Length)
                .OrderBy(x => x.Key)
                .ToArray();

            var firstInSorted = sorted.FirstOrDefault();
            if (firstInSorted == null)
                return 0;

            var queue = new List<(int length, string str)>();
            foreach (var s in firstInSorted)
            {
                queue.Add((1, s));
            }

            var result = 1;
            var visited = new HashSet<string>();
            var addedWithOne = new HashSet<string>();
            
            foreach (var grouping in sorted.Skip(1))
            {
                var queueItemsSortedByDesc = queue
                    .OrderByDescending(x => x.length)
                    .ToArray();
                
                queue.Clear();
                foreach(var queueItem in queueItemsSortedByDesc)
                {
                    if (grouping.Key - queueItem.str.Length > 1)
                    {
                        foreach (var s in grouping)
                            queue.Add((1, s));
                        break;
                    }
                    
                    foreach (var s in grouping)
                    {
                        if(visited.Contains(s))
                            continue;
                        if (Check(queueItem.str, s))
                        {
                            queue.Add((queueItem.length + 1, s));
                            result = Math.Max(result, queueItem.length + 1);
                            visited.Add(s);
                        }
                        else
                        {
                            if(addedWithOne.Contains(s))
                                continue;
                            queue.Add((1, s));
                            addedWithOne.Add(s);
                        }
                    }
                }
            }

            return result;
        }

        private bool Check(string shortStr, string longStr)
        {
            var oneSkipped = false;
            for (var i = 0; i < shortStr.Length; i++)
            {
                if (shortStr[i] != longStr[oneSkipped ? i + 1 : i])
                {
                    if (oneSkipped)
                        return false;
                    oneSkipped = true;
                    if (shortStr[i] != longStr[i + 1])
                        return false;
                }
            }

            return true;
        }
    }
}