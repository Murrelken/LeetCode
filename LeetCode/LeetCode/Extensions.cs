using System;

namespace LeetCode
{
    public static class Extensions
    {
        public static void PrintMatrix(this int[][] input)
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
}