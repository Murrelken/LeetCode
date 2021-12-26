using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.DataStructures;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem117
    {
        public Node Connect(Node root)
        {
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Any())
            {
                var queueCount = queue.Count;

                while (queueCount > 0)
                {
                    queueCount--;

                    var current = queue.Dequeue();

                    if (current?.left is null && current?.right is null) continue;

                    if (current.left is not null)
                    {
                        var leftNext = current.right ?? GetNext(current);
                        current.left.next = leftNext;
                    }

                    if (current.right is not null)
                    {
                        var rightNext = GetNext(current);
                        current.right.next = rightNext;
                    }

                    queue.Enqueue(current.left);
                    queue.Enqueue(current.right);
                }
            }

            return root;
        }

        private static Node GetNext(Node current)
        {
            while (true)
            {
                var child = current.next?.left ?? current.next?.right;
                if (child != null) return child;
                if (current.next == null) return null;
                current = current.next;
            }
        }
    }
}