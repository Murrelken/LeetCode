using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._15
{
	internal class Problem1544
	{
		public string MakeGood(string s)
		{
			var stack = new Stack<char>();

			foreach (var c in s)
				if (stack.Any() && Math.Abs(c - stack.Peek()) == 32)
					stack.Pop();
				else
					stack.Push(c);

			var resultChars = stack.ToArray();
			Array.Reverse(resultChars);

			return new string(resultChars);
		}
	}
}
