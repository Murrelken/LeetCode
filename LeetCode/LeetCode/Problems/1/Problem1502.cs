using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems;

public class Problem1502
{
    public bool CanMakeArithmeticProgression(int[] arr)
    {
        int max = arr.Max(), min = arr.Min();
        var arrLength = arr.Length;
        
        if (max == min)
            return true;
        
        if ((max - min) % (arrLength - 1) != 0)
            return false;
        
        var step = (max - min) / (arrLength - 1);
        var steps = new bool[arrLength];

        for (var i = 0; i < arrLength; i++)
        {
            var temp = arr[i] - min;
            if (temp % step != 0)
                return false;

            steps[temp / step] = true;
        }

        return steps.All(x => x);
    }
}