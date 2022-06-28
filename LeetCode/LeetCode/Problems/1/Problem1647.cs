using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem1647
    {
        public int MinDeletions(string s)
        {
            var result = 0;
            
            var freq = new Dictionary<char, int>();
            foreach (var t in s)
            {
                if (!freq.ContainsKey(t))
                    freq.Add(t, 1);
                else
                    freq[t]++;
            }

            var slots = new Stack<int>();
            var max = freq.Values.Max();
            var newDic = freq
                .GroupBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Count());

            for (var i = 1; i <= max; i++)
            {
                if(!newDic.ContainsKey(i))
                    slots.Push(i);
                else
                {
                    while (newDic[i] > 1)
                    {
                        var slotExists = slots.TryPop(out var slot);
                        result += slotExists ? i - slot : i;
                        newDic[i]--;
                    }
                }
            }

            return result;
        }
    }
}