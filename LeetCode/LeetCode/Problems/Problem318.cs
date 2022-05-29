using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem318
    {
        public int MaxProduct(string[] words)
        {
            var res = 0;
            for (var i = 0; i < words.Length; i++)
            {
                var hash = new HashSet<char>(words[i].ToCharArray());
                for (var j = i + 1; j < words.Length; j++)
                {
                    var intersects = words[j].Any(c => hash.Contains(c));

                    if(!intersects)
                        res = Math.Max(words[i].Length * words[j].Length, res);
                }
            }

            return res;
        }
    }
}