using System;
using LeetCode.DataStructures;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm1
{
    public class Problem617
    {
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 is null && root2 is null) return null;
            var newNode = new TreeNode();
            newNode.val = (root1?.val ?? 0) + (root2?.val ?? 0);
            newNode.left = MergeTrees(root1?.left, root2?.left);
            newNode.right = MergeTrees(root1?.right, root2?.right);

            return newNode;
        }
        
        public TreeNode MergeTreesNonRecursive(TreeNode root1, TreeNode root2)
        {
            throw new NotImplementedException();
        }
    }
}