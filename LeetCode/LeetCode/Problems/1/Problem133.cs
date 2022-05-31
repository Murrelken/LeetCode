using System.Collections.Generic;
using System.Linq;
using LeetCode.DataStructures.GraphNode;

namespace LeetCode.Problems
{
    public class Problem133
    {
        public Node CloneGraph(Node node)
        {
            if (node is null)
                return null;

            var newNode = new Node(node.val);
            var dic = new Dictionary<int, Node>
            {
                { node.val, newNode }
            };

            var que = new Queue<Node>();
            que.Enqueue(node);

            while (que.Any())
            {
                var count = que.Count;

                while (count > 0)
                {
                    count--;
                    var el = que.Dequeue();

                    dic.TryAdd(el.val, new Node(el.val));
                    var addedNode = dic[el.val];

                    if (addedNode.neighbors.Count != el.neighbors.Count)
                    {
                        foreach (var elNeighbor in el.neighbors)
                        {
                            dic.TryAdd(elNeighbor.val, new Node(elNeighbor.val));
                            addedNode.neighbors.Add(dic[elNeighbor.val]);
                            que.Enqueue(elNeighbor);
                        }
                    }
                }
            }

            return newNode;
        }
    }
}