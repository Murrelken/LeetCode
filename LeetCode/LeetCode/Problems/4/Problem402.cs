using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode.Problems
{
	public class Problem402
	{
		public string RemoveKdigits(string num, int k)
		{
			if (k == 0)
				return num;

			if (num.Length == k)
				return "0";

			var stack = new Stack<char>();
			foreach (var item in num)
			{
				while (stack.Count != 0 && stack.Peek() > item && k > 0)
				{
					stack.Pop();
					k--;
				}
				stack.Push(item);
			}
			while (k > 0)
			{
				stack.Pop();
				k--;
			}

			string res = string.Empty;
			while (stack.Count != 0)
				res += stack.Pop();

			char[] charArray = res.ToCharArray();
			Array.Reverse(charArray);
			res = new string(charArray);
			while (res.Length > 1 && res[0] == '0')
				res = res.Remove(0, 1);

			return res;
		}

		public string RemoveKdigitsV2(string num, int k)
		{
			var n = num.Length;

			if (n == k) return "0";

			var sb = new StringBuilder(n);
			for (var i = 0; i < n; i++)
			{
				while (k > 0 && sb.Length > 0 && sb[sb.Length - 1] > num[i])
				{
					sb.Remove(sb.Length - 1, 1);
					k--;
				}

				if (sb.Length == 0 && num[i] == '0') continue;

				sb.Append(num[i]);
			}

			while (k > 0 && sb.Length > 0)
			{
				k--;
				sb.Remove(sb.Length - 1, 1);
			}

			return sb.Length == 0 ? "0" : sb.ToString();
		}
	}
}