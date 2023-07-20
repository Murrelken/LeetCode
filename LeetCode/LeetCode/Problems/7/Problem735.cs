using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems;

public class Problem735
{
    public int[] AsteroidCollision(int[] asteroids)
    {
        var stack = new Stack<int>();

        for (var i = 0; i < asteroids.Length; i++)
        {
            var flag = true;
            while (stack.Count > 0 && stack.Peek() > 0 && asteroids[i] < 0)
            {
                if (Math.Abs(stack.Peek()) < Math.Abs(asteroids[i]))
                {
                    stack.Pop();
                    continue;
                }

                if (Math.Abs(stack.Peek()) == Math.Abs(asteroids[i]))
                    stack.Pop();

                flag = false;
                break;
            }

            if (flag)
                stack.Push(asteroids[i]);
        }

        return stack.Reverse().ToArray();
    }
}