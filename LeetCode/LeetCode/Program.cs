using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.DataStructures;
using LeetCode.Problems;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var input =
                new TreeNode(1,
                    right: new TreeNode(2,
                        right: new TreeNode(3,
                            right: new TreeNode(4,
                                right: new TreeNode(5,
                                    right: new TreeNode(6,
                                        right: new TreeNode(7,
                                            right: new TreeNode(8,
                                                right: new TreeNode(9,
                                                    right: new TreeNode(10
                                                    ))))))))));

            var copy = input;
            copy.right.right.right.right = new TreeNode(5, right: copy.right.right.right.right.right);

            var p = new Problem1379();

            var res = p.GetTargetCopy(input, copy, input.right.right.right.right);

            Console.WriteLine(res.val);
        }
    }
}