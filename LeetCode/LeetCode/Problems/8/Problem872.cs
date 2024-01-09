using LeetCode.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Problems._8
{
	internal class Problem872
	{
		private readonly List<int> _firstRootLeafs = new List<int>();
		private int _index = 0;
		private bool _abort = false;
		public bool LeafSimilar(TreeNode root1, TreeNode root2)
		{
			Dfs(root1, true);
			Dfs(root2, false);
			return !_abort && _index == _firstRootLeafs.Count;
		}

		private void Dfs(TreeNode node, bool first)
		{
			if (_abort) return;
			if (node == null) return;
			if (node.left == null && node.right == null)
			{
				if (first)
					_firstRootLeafs.Add(node.val);
				else
				{
					if (_index >= _firstRootLeafs.Count || _firstRootLeafs[_index] != node.val)
					{
						_abort = true;
						return;
					}
					else
						_index++;
				}
			}
			else
			{
				Dfs(node.left, first);
				Dfs(node.right, first);
			}
		}
	}
}
