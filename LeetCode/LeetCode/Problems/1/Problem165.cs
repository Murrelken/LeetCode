namespace LeetCode.Problems._1
{
	internal class Problem165
	{
		public int CompareVersion(string version1, string version2)
		{
			var i = 0;
			var j = 0;

			while (i < version1.Length || j < version2.Length)
			{
				var num1 = 0;
				var num2 = 0;

				while (i < version1.Length && version1[i] != '.')
				{
					num1 = num1 * 10 + (version1[i] - '0');
					i++;
				}

				while (j < version2.Length && version2[j] != '.')
				{
					num2 = num2 * 10 + (version2[j] - '0');
					j++;
				}

				if (num1 < num2) return -1;
				else if (num1 > num2) return 1;

				i++;
				j++;
			}

			return 0;
		}
	}
}
