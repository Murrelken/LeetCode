using LeetCode.DataStructures;

namespace LeetCode.Problems._1
{
	internal class Problem100
	{
		public bool IsSameTree(TreeNode p, TreeNode q)
		{
			if (p == null && q == null)
				return true;
			if (p?.val != q?.val)
				return false;
			return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
		}
	}
}
