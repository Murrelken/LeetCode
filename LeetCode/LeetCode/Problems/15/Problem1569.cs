using LeetCode.DataStructures;

namespace LeetCode.Problems;

public class Problem1569
{
    private const int Mod = 1000000007;
    private static long[][] _pascalTriangle;

    public int NumOfWays(int[] nums)
    {
        FormPascalTriangle(nums.Length);
        var root = CreateTree(nums);

        return GetCountForTreeNode(root) - 1;
    }

    private static int GetCountForTreeNode(TreeNode node)
    {
        if (node is null)
            return 1;

        var (leftBranchCount, rightBranchCount) = CountBranchesLength(node);

        return (int)
            (_pascalTriangle[leftBranchCount + rightBranchCount][leftBranchCount] *
                (GetCountForTreeNode(node.left) % Mod) % Mod * GetCountForTreeNode(node.right) % Mod);
    }

    private static TreeNode CreateTree(int[] nums)
    {
        var root = new TreeNode(nums[0]);
        for (var i = 1; i < nums.Length; i++)
        {
            var tempRoot = root;
            while (true)
            {
                if (nums[i] < tempRoot.val)
                    if (tempRoot.left == null)
                    {
                        tempRoot.left = new TreeNode(nums[i]);
                        break;
                    }
                    else
                        tempRoot = tempRoot.left;
                else if (tempRoot.right == null)
                {
                    tempRoot.right = new TreeNode(nums[i]);
                    break;
                }
                else
                    tempRoot = tempRoot.right;
            }
        }

        return root;
    }

    private static (int, int) CountBranchesLength(TreeNode node)
    {
        return (CountBranchLength(node.left), CountBranchLength(node.right));
    }

    private static int CountBranchLength(TreeNode node)
    {
        if (node is null)
            return 0;

        return 1 + CountBranchLength(node.left) + CountBranchLength(node.right);
    }

    private static void FormPascalTriangle(int n)
    {
        _pascalTriangle = new long[n][];
        for (var i = 0; i < n; i++)
            _pascalTriangle[i] = new long[n];

        for (var i = 0; i < n; i++)
        {
            _pascalTriangle[i][0] = 1;
            _pascalTriangle[i][i] = 1;
        }

        for (var i = 2; i < n; i++)
        for (var j = 1; j < i; j++)
            _pascalTriangle[i][j] = (_pascalTriangle[i - 1][j] + _pascalTriangle[i - 1][j - 1]) % Mod;
    }
}