using System;
using System.Collections.Generic;

namespace LeetCode.Problems
{
    public class Problem1679
    {
        public int MaxOperations(int[] nums, int k)
        {
            var dic = new Dictionary<int, int>();
            var res = 0;

            foreach (var num in nums)
            {
                if (!dic.TryAdd(num, 1))
                    dic[num]++;
            }
            
            foreach (var (key, value) in dic)
            {
                var dif = k - key;

                if (dif == key)
                {
                    res += value / 2;
                    // dic[key] = value % 2;
                }
                else
                {
                    if(!dic.ContainsKey(dif)) continue;
                    var min = Math.Min(dic[key], dic[dif]);
                    res += min;
                    dic[key] -= min;
                    dic[dif] -= min;
                }
            }

            return res;
        }
    }
}