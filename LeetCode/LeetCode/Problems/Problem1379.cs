using System;
using System.Collections.Generic;
using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem1379
    {
        private bool _found;
        
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            _found = false;
            var steps = new Stack<LeftRight>();
            Dfs(original, target, steps);
            
            foreach (var leftRight in steps)
            {
                switch (leftRight)
                {
                    case LeftRight.Left:
                        cloned = cloned.left;
                        break;
                    case LeftRight.Right:
                        cloned = cloned.right;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return cloned;
        }

        private void Dfs(TreeNode currentNode, TreeNode target, Stack<LeftRight> steps)
        {
            if (currentNode is null || _found)
                return;

            if (currentNode == target)
            {
                _found = true;
                return;
            }
            
            steps.Push(LeftRight.Left);
            Dfs(currentNode.left, target, steps);
            if(_found)
                return;
            steps.Pop();
            
            steps.Push(LeftRight.Right);
            Dfs(currentNode.right, target, steps);
            if(_found)
                return;
            steps.Pop();
        }
        
        private enum LeftRight
        {
            Left,
            Right
        }
    }
}