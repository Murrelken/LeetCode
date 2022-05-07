using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem456
    {
        public bool Find132pattern(int[] nums)
        {
            var n = nums.Length;

            var stack = new Stack<int>();

            var middleValue = int.MinValue;

            for (int i = n - 1; i >= 0; i--)
            {
                var curNum = nums[i];

                if (curNum < middleValue) return true;
                else
                {
                    while (stack.Any() && curNum > stack.Peek())
                    {
                        middleValue = Math.Max(middleValue, stack.Pop());
                    }
                }

                stack.Push(curNum);
            }

            return false;
        }
    }
}