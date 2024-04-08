namespace LeetCode.Problems._17
{
	internal class Problem1700
	{
		public int CountStudents(int[] students, int[] sandwiches)
		{
			var count = new int[2];

			foreach (var student in students)
				count[student]++;

			var i = 0;
			while (i < sandwiches.Length)
			{
				if (count[sandwiches[i]] == 0)
					break;

				count[sandwiches[i]]--;

				i++;
			}

			return students.Length - i;
		}
	}
}
