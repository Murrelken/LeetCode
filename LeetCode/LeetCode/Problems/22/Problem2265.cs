using LeetCode.DataStructures;
using System;

public class Problem2265
{
    private static int _count = 0;
    public int AverageOfSubtree(TreeNode root)
    {
        _count = 0;
        Dfs(root);
        return _count;
    }

    public (int sum, int count) Dfs(TreeNode node)
    {
        var childCount = 0;
        var childSum = 0;

        if (node.left != null)
        {
            var (leftSum, leftCount) = Dfs(node.left);
            childCount += leftCount;
            childSum += leftSum;
        }

        if (node.right != null)
        {
            var (rightSum, rightCount) = Dfs(node.right);
            childCount += rightCount;
            childSum += rightSum;
        }

        childSum += node.val;
        childCount += 1;

        if (childSum / childCount == node.val)
            _count++;

        return (childSum, childCount);
    }
}