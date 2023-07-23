using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class Problem894
{
    Dictionary<int, IList<TreeNode>> _memo = new();

    public IList<TreeNode> AllPossibleFBT(int n)
    {
        if (_memo.TryGetValue(n, out var fbt)) return fbt;
        var list = new List<TreeNode>();
        if (n == 1)
            list.Add(new TreeNode());
        else if (n % 2 == 1)
        {
            for (var i = 0; i < n; ++i)
            {
                var j = n - 1 - i;
                foreach (var left in AllPossibleFBT(i))
                foreach (var right in AllPossibleFBT(j))
                {
                    var root = new TreeNode(0, left, right);
                    list.Add(root);
                }
            }
        }

        return _memo[n] = list;
    }
}