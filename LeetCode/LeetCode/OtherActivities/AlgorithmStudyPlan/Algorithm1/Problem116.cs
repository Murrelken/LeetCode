using System;
using System.ComponentModel;
using LeetCode.DataStructures;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem116
    {
        public Node Connect(Node root)
        {
            if (root?.left is not null)
            {
                root.left.next = root.right;
                root.right.next = root.next?.left;
                Connect(root.left);
                Connect(root.right);
            }
            return root;
        }
        
        public TreeNode ConnectNonRecursive(Node root)
        {
            throw new NotImplementedException();
        }
    }
}