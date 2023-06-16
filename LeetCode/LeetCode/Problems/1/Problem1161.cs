using System.Collections.Generic;
using System.Linq;
using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class Problem1161
{
    public int MaxLevelSum(TreeNode root)
    {
        int maxSum = int.MinValue, level = 0, step = 0;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Any())
        {
            step++;
            var count = queue.Count;
            var tempSum = 0;
            while (count > 0)
            {
                count--;
                var el = queue.Dequeue();
                tempSum += el.val;
                if (el.left != null)
                    queue.Enqueue(el.left);
                if (el.right != null)
                    queue.Enqueue(el.right);
            }

            if (tempSum <= maxSum) continue;
            maxSum = tempSum;
            level = step;
        }

        return level;
    }
}