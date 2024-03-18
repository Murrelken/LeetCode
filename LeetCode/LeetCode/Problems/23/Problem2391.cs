using System.Linq;

namespace LeetCode.Problems._23
{
	internal class Problem2391
	{
		public int GarbageCollection(string[] garbage, int[] travel)
		{
			var lastM = 0;
			var lastP = 0;
			var lastG = 0;

			for (int i = garbage.Length - 1; i > 0; i--)
			{
				if (lastM == 0 && garbage[i].Contains('M'))
					lastM = i;

				if (lastP == 0 && garbage[i].Contains('P'))
					lastP = i;

				if (lastG == 0 && garbage[i].Contains('G'))
					lastG = i;

				if (lastM != 0 && lastP != 0 && lastG != 0)
					break;
			}

			return
				travel.Take(lastM).Sum() +
				travel.Take(lastP).Sum() +
				travel.Take(lastG).Sum() +
				garbage.Select(x => x.Length).Sum();
		}

		public int GarbageCollectionV2(string[] garbage, int[] travel)
		{
			var sum = 0;

			var mFound = false;
			var pFound = false;
			var gFound = false;

			for (int i = garbage.Length - 1; i > 0; i--)
			{
				if (!mFound && garbage[i].Contains('M'))
					mFound = true;
				if (!pFound && garbage[i].Contains('P'))
					pFound = true;
				if (!gFound && garbage[i].Contains('G'))
					gFound = true;

				sum += garbage[i].Length;
				if (mFound)
					sum += travel[i - 1];
				if (pFound)
					sum += travel[i - 1];
				if (gFound)
					sum += travel[i - 1];
			}

			return sum + garbage[0].Length;
		}
	}
}
