using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem700
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            while (root != null)
            {
                if (val == root.val)
                    break;

                root = val < root.val
                    ? root.left
                    : root.right;
            }

            return root;
        }
    }
}