using System.Collections.Generic;
using System.Linq;
using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem1302
    {
        public int DeepestLeavesSum(TreeNode root)
        {
            var result = -1;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                result = 0;
                var count = queue.Count;
                while (count > 0)
                {
                    count--;
                    var deq = queue.Dequeue();
                    result += deq.val;
                    if (deq.left != null)
                        queue.Enqueue(deq.left);
                    if (deq.right != null)
                        queue.Enqueue(deq.right);
                }
            }

            return result;
        }
    }
}