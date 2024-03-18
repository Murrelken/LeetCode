using System.Collections.Generic;

namespace LeetCode.Problems._14
{
	internal class Problem1496
	{
		public bool IsPathCrossing(string path)
		{
			int x = 0, y = 0;
			HashSet<string> visited = new HashSet<string> { "0,0" };

			foreach (char direction in path)
			{
				if (direction == 'E')
					x++;
				else if (direction == 'W')
					x--;
				else if (direction == 'N')
					y++;
				else if (direction == 'S')
					y--;

				string currentPos = $"{x},{y}";
				if (visited.Contains(currentPos))
					return true;

				visited.Add(currentPos);
			}

			return false;
		}
	}
}
