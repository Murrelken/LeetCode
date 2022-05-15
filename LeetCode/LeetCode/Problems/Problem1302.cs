using System.Collections.Generic;
using System.Linq;
using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem1302
    {
        public int DeepestLeavesSum(TreeNode root)
        {
            var result = new List<int>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var count = queue.Count;
                var sum = 0;
                while (count > 0)
                {
                    count--;
                    var deq = queue.Dequeue();
                    sum += deq.val;
                    if (deq.left != null)
                        queue.Enqueue(deq.left);
                    if (deq.right != null)
                        queue.Enqueue(deq.right);
                }

                result.Add(sum);
            }

            return result.Last();
        }
    }
}