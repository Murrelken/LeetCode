namespace LeetCode.Problems._7
{
	internal class Problem79
	{
		public bool Exist(char[][] board, string word)
		{
			var m = board.Length;
			var n = board[0].Length;

			for (int i = 0; i < m; ++i)
				for (int j = 0; j < n; ++j)
					if (NewMethod(i, j, 0, board, word, m, n))
						return true;

			return false;
		}

		private static bool NewMethod(int i, int j, int k, char[][] board, string word, int m, int n)
		{
			if (k == word.Length)
				return true;

			if (i < 0 || i >= m || j < 0 || j >= n || board[i][j] != word[k])
				return false;

			var temp = board[i][j];
			board[i][j] = '\0';
			var result = NewMethod(i + 1, j, k + 1, board, word, m, n) ||
						  NewMethod(i - 1, j, k + 1, board, word, m, n) ||
						  NewMethod(i, j + 1, k + 1, board, word, m, n) ||
						  NewMethod(i, j - 1, k + 1, board, word, m, n);

			board[i][j] = temp;
			return result;
		}
	}
}
