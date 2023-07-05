using System;

namespace LeetCode.Problems
{
    public class Problem1689
    {
        public int MinPartitions(string n)
        {
            var max = 0;
            for (var i = 0; i < n.Length; i++)
            {
                int.TryParse($"{n[i]}", out var parsed);
                if (parsed == 9)
                {
                    max = 9;
                    break;
                }
                else if (parsed > max)
                    max = parsed;
            }

            return max;
        }
    }
}