using LeetCode.DataStructures;

namespace LeetCode.OtherActivities.AlgorithmStudyPlan.Algorithm2
{
    public class Problem572
    {
        public bool IsSubtree(TreeNode root, TreeNode subRoot) 
        {
            if (root is not null)
            {
                var check = false;
                if (root.val == subRoot.val)
                    check = Check(root, subRoot);
                if (check)
                    return true;
                var recLeft = IsSubtree(root.left, subRoot);
                if (recLeft)
                    return true;
                var recRight = IsSubtree(root.right, subRoot);
                if (recRight)
                    return true;
            }
            return false;
        }

        private bool Check(TreeNode root, TreeNode subRoot)
        {
            if (root is null && subRoot is null)
                return true;
            if (root?.val != subRoot?.val)
                return false;
            return Check(root.left, subRoot.left) && Check(root.right, subRoot.right);
        }
    }
}