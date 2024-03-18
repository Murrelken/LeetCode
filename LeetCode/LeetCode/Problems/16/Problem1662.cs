namespace LeetCode.Problems._16
{
	internal class Problem1662
	{
		public bool ArrayStringsAreEqual(string[] word1, string[] word2)
		{
			var leftI = 0;
			var rightI = 0;
			var leftWordI = 0;
			var rightWordI = 0;

			while (true)
			{
				if (leftI == word1.Length || rightI == word2.Length) break;
				if (word1[leftI][leftWordI] != word2[rightI][rightWordI]) return false;
				leftWordI++;
				rightWordI++;
				if (leftWordI == word1[leftI].Length)
				{
					leftWordI = 0;
					leftI++;
				}
				if (rightWordI == word2[rightI].Length)
				{
					rightWordI = 0;
					rightI++;
				}
			}

			return leftI == word1.Length && rightI == word2.Length;
		}
	}
}
