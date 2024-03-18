using LeetCode.DataStructures;
using System.Collections.Generic;
using System;
using System.Linq;

public class Problem515
{
    public IList<int> LargestValues(TreeNode root)
    {
        var q = new Queue<TreeNode>();
        if (root is not null)
            q.Enqueue(root);

        var res = new List<int>();

        while (q.Any())
        {
            var count = q.Count();

            var max = int.MinValue;
            while (count > 0)
            {
                count--;
                var current = q.Dequeue();
                max = Math.Max(max, current.val);
                if (current.left is not null)
                    q.Enqueue(current.left);
                if (current.right is not null)
                    q.Enqueue(current.right);
            }

            res.Add(max);
        }

        return res;
    }
}