using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem20
    {
        public bool IsValid(string s)
        {
            var currentType = new Stack<int>();
            var temp = new int[3];

            for (var i = 0; i < s.Length; i++)
            {
                char c = s[i];
                var index = GetIndex(c);
                if (c is ']' or '}' or ')')
                {
                    if (temp[index] == 0 || currentType.Peek() != index)
                        return false;
                    else
                        temp[index]--;

                    currentType.Pop();
                }
                else
                {
                    temp[index]++;
                    currentType.Push(index);
                }
            }

            return temp.All(x => x == 0);
        }

        private int GetIndex(char c)
        {
            switch (c)
            {
                case '[':
                case ']':
                    return 0;
                case '(':
                case ')':
                    return 1;
                case '{':
                case '}':
                    return 2;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}