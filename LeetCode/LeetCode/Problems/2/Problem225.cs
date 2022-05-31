using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems
{
    public class Problem225
    {
        public class MyStack
        {
            private Queue<int> _stack = new();
            private Queue<int> _temp = new();
            public MyStack()
            {
            }

            public void Push(int x)
            {
                _stack.Enqueue(x);
            }

            public int Pop()
            {
                var last = -1;
                while (_stack.Any())
                {
                    var deq = _stack.Dequeue();
                    last = deq;
                    if(_stack.Any())
                        _temp.Enqueue(deq);
                }

                while (_temp.Any())
                {
                    _stack.Enqueue(_temp.Dequeue());
                }

                return last;
            }

            public int Top()
            {
                var last = -1;
                while (_stack.Any())
                {
                    var deq = _stack.Dequeue();
                    last = deq;
                    _temp.Enqueue(deq);
                }

                while (_temp.Any())
                {
                    _stack.Enqueue(_temp.Dequeue());
                }

                return last;
            }

            public bool Empty()
                => !_stack.Any();
            
        }
    }
}