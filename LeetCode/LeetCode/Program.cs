using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.DataStructures;
using LeetCode.Problems;
using LeetCode.Problems._4;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputStr = "[10,16],[2,8],[1,6],[7,12]";

			var p = new Problem452();
            var input = GetInput<int>(inputStr, Int32.Parse);
            var res = p.FindMinArrowShots(input);

            Console.WriteLine(res);
        }

        private static T[][] GetInput<T> (string inputStr, Func<string, T> conv)
        {
            var res = new List<T[]>();
            var a = inputStr.Split('[').Skip(1);
            foreach (var t in a)
            {
                var withComma = t.Split(']')[0];
                var values = withComma.Split(",").Select(conv).ToArray();
                res.Add(values);
            }
            return res.ToArray();
        }
    }
}