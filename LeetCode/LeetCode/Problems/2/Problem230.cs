using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem230
    {
        private int _current;
        private int _target = -1;
        
        public int KthSmallest(TreeNode root, int k)
        {
            Helper(root, k);
            return _target;
        }

        private void Helper(TreeNode node, int k)
        {
            if (_target != -1)
                return;
            
            if (node.left is not null)
                Helper(node.left, k);

            _current++;

            if (_current == k)
                _target = node.val;

            if (node.right is not null)
                Helper(node.right, k);
        }
    }
}