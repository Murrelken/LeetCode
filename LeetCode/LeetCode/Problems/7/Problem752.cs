using System.Collections.Generic;

namespace LeetCode.Problems._7
{
	internal class Problem752
	{
		public int OpenLock(string[] deadends, string target)
		{
			var deadSet = new HashSet<string>(deadends);
			var visited = new HashSet<string>();
			var queue = new Queue<string>();
			queue.Enqueue("0000");
			visited.Add("0000");
			var level = 0;

			while (queue.Count > 0)
			{
				var size = queue.Count;
				for (var i = 0; i < size; i++)
				{
					string current = queue.Dequeue();
					if (deadSet.Contains(current)) continue;
					if (current == target) return level;

					for (var j = 0; j < 4; j++)
					{
						for (var k = -1; k <= 1; k += 2)
						{
							var currentArray = current.ToCharArray();
							var digit = (currentArray[j] - '0' + k + 10) % 10;
							currentArray[j] = (char)(digit + '0');
							var next = new string(currentArray);
							if (!visited.Contains(next) && !deadSet.Contains(next))
							{
								queue.Enqueue(next);
								visited.Add(next);
							}
						}
					}
				}

				level++;
			}

			return -1; // Target not reachable
		}
	}
}
