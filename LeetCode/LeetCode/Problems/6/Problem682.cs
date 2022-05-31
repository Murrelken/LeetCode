using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem682
    {
        public int CalPoints(string[] ops)
        {
            var l = new List<int>();
            foreach (var op in ops)
            {
                Helper(l, op);
            }

            return l.Sum();
        }

        private void Helper(List<int> result, string action)
        {
            switch (action)
            {
                case "+":
                    result.Add(result[^1] + result[^2]);
                    break;
                case "C":
                    result.RemoveAt(result.Count - 1);
                    break;
                case "D":
                    result.Add(2 * result[^1]);
                    break;
                default:
                    if (int.TryParse(action, out var n))
                    {
                        result.Add(n);
                        break;
                    }
                    else
                        throw new ArgumentOutOfRangeException();
            }
        }
    }
}