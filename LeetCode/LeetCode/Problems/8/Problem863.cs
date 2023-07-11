using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class Problem863
{
    private IList<int> _result = new List<int>();
    private int _k;

    public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
    {
        _k = k;

        FindTargetDepth(root, target);

        return _result;
    }

    private int FindTargetDepth(TreeNode root, TreeNode target)
    {
        if (root == null)
            return -1;

        if (root == target)
        {
            Req(root, -1);
            return 1;
        }

        var leftDepth = FindTargetDepth(root.left, target);
        if (leftDepth > 0)
        {
            if(leftDepth == _k)
                _result.Add(root.val);
            else
                Req(root.right, leftDepth);

            return leftDepth + 1;
        }

        var rightDepth = FindTargetDepth(root.right, target);
        if (rightDepth > 0)
        {
            if(rightDepth == _k)
                _result.Add(root.val);
            else
                Req(root.left, rightDepth);
        }

        return rightDepth > 0 ? rightDepth + 1 : -1;
    }

    private void Req(TreeNode root, int depth)
    {
        depth++;
        
        if (root == null)
            return;
        
        if(depth == _k)
            _result.Add(root.val);
        else
        {
            Req(root.left, depth);
            Req(root.right, depth);
        }
    }
}