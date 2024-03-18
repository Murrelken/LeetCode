using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._2
{
	internal class Problem232
	{
		public class MyQueue
		{
			private readonly Stack<int> _queue;
			private readonly Stack<int> _queueForReverse;

			public MyQueue()
			{
				_queue = new Stack<int>();
				_queueForReverse = new Stack<int>();
			}

			public void Push(int x)
			{
				_queue.Push(x);
			}

			public int Pop()
			{
				while (_queue.Count > 0)
					_queueForReverse.Push(_queue.Pop());
				var item = _queueForReverse.Pop();
				while (_queueForReverse.Count > 0)
					_queue.Push(_queueForReverse.Pop());
				return item;
			}

			public int Peek()
			{
				while (_queue.Count > 0)
					_queueForReverse.Push(_queue.Pop());
				var item = _queueForReverse.Peek();
				while (_queueForReverse.Count > 0)
					_queue.Push(_queueForReverse.Pop());
				return item;
			}

			public bool Empty()
			{
				return !_queue.Any();
			}
		}
	}
}
