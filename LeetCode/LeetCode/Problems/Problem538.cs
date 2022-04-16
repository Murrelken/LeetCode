using System;
using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem538
    {
        public TreeNode ConvertBST(TreeNode root)
        {
            Helper(root, 0);
            return root;
        }

        private int Helper(TreeNode node, int prevSum)
        {
            if (node == null)
                return 0;

            var r = Helper(node.right, prevSum);
            node.val += r;
            if (node.right == null)
                node.val += prevSum;
            var l = Helper(node.left, node.val);

            return node.left == null ? node.val : l;
        }
    }
}