using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem99
    {
        private TreeNode _fifthColumn;
        private TreeNode _sixthColumn;
        private TreeNode _prev = new(int.MinValue);

        public void RecoverTree(TreeNode root)
        {
            if (root == null)
                return;

            Dfs(root);
            (_fifthColumn.val, _sixthColumn.val) = (_sixthColumn.val, _fifthColumn.val);
        }

        private void Dfs(TreeNode root)
        {
            if (root == null)
                return;

            Dfs(root.left);

            if (_fifthColumn == null && root.val < _prev.val)
                _fifthColumn = _prev;

            if (_fifthColumn != null && root.val < _prev.val)
                _sixthColumn = root;

            _prev = root;

            Dfs(root.right);
        }
    }
}