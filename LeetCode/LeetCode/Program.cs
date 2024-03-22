using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.DataStructures;
using LeetCode.Problems;
using LeetCode.Problems._2;
using LeetCode.Problems._4;

namespace LeetCode
{
	class Program
	{
		static void Main(string[] args)
		{
			var inputStr = "[10,16],[2,8],[1,6],[7,12]";

			var p = new Problem234();
			var input = GetInput<int>(inputStr, Int32.Parse);
			var res = p.IsPalindrome(GetLinkedListFromList(new[] { 8, 0, 7, 1, 7, 7, 9, 7, 5, 2, 9, 1, 7, 3, 7, 0, 6, 5, 1, 7, 7, 9, 3, 8, 1, 5, 7, 7, 8, 4, 0, 9, 3, 7, 3, 4, 5, 7, 4, 8, 8, 5, 8, 9, 8, 5, 8, 8, 4, 7, 5, 4, 3, 7, 3, 9, 0, 4, 8, 7, 7, 5, 1, 8, 3, 9, 7, 7, 1, 5, 6, 0, 7, 3, 7, 1, 9, 2, 5, 7, 9, 7, 7, 1, 7, 0, 8 }));

			Console.WriteLine(res);
		}

		private static T[][] GetInput<T>(string inputStr, Func<string, T> conv)
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

		private static ListNode GetLinkedListFromList(IEnumerable<int> list)
		{
			ListNode result = null;

			foreach (var item in list.Reverse())
				result = new ListNode(item, result);

			return result;
		}
	}
}