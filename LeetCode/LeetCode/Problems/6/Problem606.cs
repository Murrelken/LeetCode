using LeetCode.DataStructures;
using System.Text;

namespace LeetCode.Problems._6
{
	internal class Problem606
	{
		public string Tree2str(TreeNode root)
		{
			var sb = new StringBuilder();
			Write(root, sb);
			var res = sb.ToString().Substring(1, sb.Length - 2);
			return res;
		}

		private void Write(TreeNode node, StringBuilder sb)
		{
			sb.Append("(");
			if (node != null)
			{
				sb.Append(node.val);
				if (node.left != null || node.right != null) 
				{
					Write(node.left, sb);
					if (node.right != null)
						Write(node.right, sb);
				}
			}

			sb.Append(")");
		}
	}
}
