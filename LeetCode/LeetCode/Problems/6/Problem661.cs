namespace LeetCode.Problems._6
{
	internal class Problem661
	{
		public int[][] ImageSmoother(int[][] img)
		{
			int[][] result = new int[img.Length][];

			for (int y = 0; y < img.Length; y++)
			{
				result[y] = new int[img[0].Length];
				for (int x = 0; x < img[0].Length; x++)
					result[y][x] = GetAvgSum(img, x, y);
			}

			return result;
		}

		private static int GetAvgSum(int[][] img, in int inX, in int inY)
		{
			int sum = 0;
			int c = 0;

			for (int y = inY - 1; y <= inY + 1; y++)
			{
				if (y < 0 || y >= img.Length) continue;

				for (int x = inX - 1; x <= inX + 1; x++)
				{
					if (x < 0 || x >= img[0].Length) continue;

					sum += img[y][x];
					c++;
				}
			}

			return sum / c;
		}
	}
}
