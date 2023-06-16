using System;
using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class Problem530
{
    public int GetMinimumDifference(TreeNode root)
    {
        if (root == null)
            return int.MaxValue;

        var mostRightFromLeft = root.left;
        while (mostRightFromLeft?.right != null)
            mostRightFromLeft = mostRightFromLeft.right;

        var mostLeftFromRight = root.right;
        while (mostLeftFromRight?.left != null)
            mostLeftFromRight = mostLeftFromRight.left;

        var curLeft = mostRightFromLeft != null
            ? root.val - mostRightFromLeft.val
            : int.MaxValue;
        var curRight = mostLeftFromRight != null
            ? mostLeftFromRight.val - root.val
            : int.MaxValue;

        var curMin = Math.Min(curLeft, curRight);
        var leftMin = GetMinimumDifference(root.left);
        var rightMin = GetMinimumDifference(root.right);
        var childrenMin = Math.Min(leftMin, rightMin);

        return Math.Min(curMin, childrenMin);
    }
}