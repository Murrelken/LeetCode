using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using LeetCode.DataStructures;

namespace LeetCode.Problems
{
    public class Problem173
    {
        public class BSTIterator
        {
            private readonly TreeNode _root;
            private readonly Stack<TreeNode> _stack = new();
            private TreeNode _current;

            public BSTIterator(TreeNode root)
            {
                _root = root;
                while (root != null)
                {
                    _stack.Push(root);
                    root = root.left;
                }

                var last = _stack.Peek();
                last.left = new TreeNode(-1);
                _current = last.left;
            }

            public int Next()
            {
                if (_current.right != null)
                {
                    _stack.Push(_current);
                    _current = _current.right;

                    while (_current.left != null)
                    {
                        _stack.Push(_current);
                        _current = _current.left;
                    }
                }
                else
                {
                    var p = _stack.Peek();
                    while (p.val < _current.val)
                    {
                        _current = _stack.Pop();
                        p = _stack.Peek();
                    }
                    _current = p;
                    _stack.Pop();
                }
                return _current.val;
            }

            public bool HasNext()
            {
                if (_root.val > _current.val || _current.right != null)
                    return true;
                var localStack = new Stack<TreeNode>();
                var found = false;

                while (_stack.Any())
                {
                    var p = _stack.Pop();
                    localStack.Push(p);
                    if (p.val > _current.val)
                    {
                        found = true;
                        break;
                    }
                }

                while (localStack.Any())
                {
                    var p = localStack.Pop();
                    _stack.Push(p);
                }

                return found;
            }
        }
    }
}