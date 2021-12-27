using System;
using LeetCode.Problems;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var problemInstance = new Problem3();

            var str = "abac";
            Console.WriteLine(str + " " + problemInstance.LengthOfLongestSubstring(str));
        }
    }
}