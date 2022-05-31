using System.Collections.Generic;
using System.Linq;
using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem104
    {
        public int MaxDepth(TreeNode root)
        {
            if (root is null)
                return 0;

            var que = new Queue<TreeNode>();
            que.Enqueue(root);

            var layerCount = 0;

            while (que.Any())
            {
                layerCount++;

                var queCount = que.Count;

                while (queCount > 0)
                {
                    queCount--;
                    var item = que.Dequeue();
                    if (item is null)
                        continue;

                    que.Enqueue(item.left);
                    que.Enqueue(item.right);
                }
            }

            return layerCount - 1;
        }
    }
}