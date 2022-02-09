using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem532
    {
        public int FindPairs(int[] nums, int k)
        {
            var dic = new Dictionary<int, TwoIntegersItem>();

            foreach (var num in nums)
            {
                if (!dic.ContainsKey(num))
                {
                    var minus = num - k;
                    var plus = num + k;

                    if (dic.TryGetValue(minus, out var valueM))
                    {
                        valueM.Plus = num;
                        dic.Add(num, new TwoIntegersItem());
                        dic[num].Minus = minus;
                    }

                    if (dic.TryGetValue(plus, out var valueP))
                    {
                        valueP.Minus = num;
                        dic.TryAdd(num, new TwoIntegersItem());
                        dic[num].Plus = plus;
                    }
                    
                    if(!dic.ContainsKey(num))
                        dic.Add(num, new TwoIntegersItem());
                }
                else if (k == 0)
                {
                    dic[num].Minus = num;
                    dic[num].Plus = num;
                }
            }

            var hashset = new HashSet<(int one, int two)>();
            
            foreach (var keyValue in dic)
            {
                var key = keyValue.Key;
                var m = keyValue.Value.Minus;
                var p = keyValue.Value.Plus;
            
                if (m is not null)
                    hashset.Add((Math.Min(key, m.Value), Math.Max(key, m.Value)));
            
                if (p is not null)
                    hashset.Add((Math.Min(key, p.Value), Math.Max(key, p.Value)));
            }
            
            return hashset.Count;

            // var hash = new HashSet<int>();
            //
            // var suitableElements = dic
            //     .Where(x => x.Value.Minus is not null || x.Value.Plus is not null)
            //     .ToArray();
            //
            // foreach (var keyValuePair in suitableElements)
            // {
            //     hash.Add(keyValuePair.Key);
            //     if (keyValuePair.Value.Minus is not null)
            //         hash.Add(keyValuePair.Value.Minus.Value);
            //     if (keyValuePair.Value.Plus is not null)
            //         hash.Add(keyValuePair.Value.Plus.Value);
            // }
            //
            // return k == 0
            //     ? hash.Count
            //     : hash.Count - 1;
        }

        class TwoIntegersItem
        {
            public int? Minus { get; set; }

            public int? Plus { get; set; }
        }
    }
}