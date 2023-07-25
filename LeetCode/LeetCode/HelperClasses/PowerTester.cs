using System;
using LeetCode.Problems;

namespace LeetCode.HelperClasses;

public static class PowerTester
{
    public static void Test()
    {
        var p = new Problem50();
        // Console.WriteLine("RunMathPower");
        // for (var i = 0; i < 100; i++)
        // {
        //     RunPower(true, null);
        // }
        Console.WriteLine("RunMyPower");
        for (var i = 0; i < 100; i++)
        {
            RunPower(false, p);
        }
    }

    private const int Cap = 1000;

    private static void RunPower(bool isMath, Problem50 p)
    {
        var startTime = DateTime.Now;
        double res = 0;
        for (double i = -50.0; i <= 50; i += 0.2)
        {
            for (int j = -Cap; j < Cap; j++)
            {
                res += isMath ? Math.Pow(i, j) : p.MyPow(i, j);
            }
        }

        var endTime = DateTime.Now;
        Console.WriteLine((endTime - startTime).TotalMilliseconds);
    }
}