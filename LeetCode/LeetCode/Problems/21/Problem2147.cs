namespace LeetCode.Problems._21
{
	internal class Problem2147
	{
		public int NumberOfWays(string corridor)
		{
			const int MOD = 1_000_000_007;
			var result = 1L;
			var lookingForSecondSeat = true;
			var initialIndex = corridor.IndexOf('S') + 1;
			var tempWallsOptions = 0L;

			for (var i = initialIndex; i < corridor.Length; i++)
			{
				var current = corridor[i];
				if (lookingForSecondSeat)
				{
					if (current == 'S') lookingForSecondSeat = false;
					else continue;
				}
				else
				{
					tempWallsOptions++;
					if (current == 'S')
					{
						lookingForSecondSeat = true;
						result = (result % MOD * tempWallsOptions) % MOD;
						tempWallsOptions = 0;
					}
				}
			}

			return lookingForSecondSeat ? 0 : (int)result;
		}
	}
}
