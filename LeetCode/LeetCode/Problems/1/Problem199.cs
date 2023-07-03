using System.Collections.Generic;
using System.Linq;
using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem199
    {
        public IList<int> RightSideView(TreeNode root)
        {
            var result = new List<int>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var count = queue.Count;
                var last = 0;
                while (count > 0)
                {
                    count--;
                    var curr = queue.Dequeue();
                    if (curr is null)
                        continue;
                    last = curr.val;
                    queue.Enqueue(curr.left);
                    queue.Enqueue(curr.right);
                }

                result.Add(last);
            }

            return result.SkipLast(1).ToList();
        }
    }
}