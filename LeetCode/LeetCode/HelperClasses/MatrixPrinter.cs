using System;
using System.Collections.Generic;

namespace LeetCode.HelperClasses;

public static class MatrixPrinter
{
    public static void PrintMatrix<T>(this IEnumerable<IEnumerable<T>> input)
    {
        Console.WriteLine("----");
        foreach (var t in input)
        {
            Console.WriteLine();
            foreach (var t1 in t)
            {
                Console.Write(t1 + " ");
            }
        }

        Console.WriteLine();
    }
}