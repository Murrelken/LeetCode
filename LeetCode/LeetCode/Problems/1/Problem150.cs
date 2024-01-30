using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems._1
{
	internal class Problem150
	{
		public int EvalRPN(string[] tokens)
		{
			var stack = new Stack<int>();

            foreach (var item in tokens)
            {
                if (int.TryParse(item, out var n))
					stack.Push(n);
				else
				{
					var s = stack.Pop();
					var f = stack.Pop();
					var r = item switch
					{
						"+" => f + s,
						"-" => f - s,
						"*" => f * s,
						"/" => f / s,
						_ => 0
					};
					stack.Push(r);
				}
            }

			return stack.Pop();
        }
	}
}
