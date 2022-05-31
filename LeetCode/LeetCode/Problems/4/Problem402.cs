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
    }
}