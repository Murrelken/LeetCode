using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.DataStructures;

namespace LeetCode.HelperClasses;

public static class TreeNodePrinter
{
    public static void PrintTreeNode(this TreeNode treeNode)
    {
        var list = new List<TreeNode> { treeNode };

        while (list.Any())
        {
            Console.Write(string.Join(' ', list.Select(x => x?.val.ToString() ?? "n")));
            Console.WriteLine();
            var tempList = new List<TreeNode>();
            foreach (var node in list)
            {
                if (node == null) continue;
                tempList.Add(node.left);
                tempList.Add(node.right);
            }

            list = tempList;
        }

        Console.WriteLine();
    }
}