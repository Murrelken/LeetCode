using System.Collections.Generic;
using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem897
    {
        private List<TreeNode> _nodes = new List<TreeNode>();

        public TreeNode IncreasingBST(TreeNode root)
        {
            var mostLeft = root;
            while (mostLeft.left is not null)
                mostLeft = mostLeft.left;
            Helper(root);

            for (var i = 1; i < _nodes.Count; i++)
            {
                _nodes[i - 1].right = _nodes[i];
                _nodes[i].left = null;
            }

            return mostLeft;
        }

        private void Helper(TreeNode root)
        {
            if (root.left is not null)
                Helper(root.left);

            _nodes.Add(root);

            if (root.right is not null)
                Helper(root.right);
        }
    }
}