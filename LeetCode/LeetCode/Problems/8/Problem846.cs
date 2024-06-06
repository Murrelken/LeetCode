using System;
using System.Collections.Generic;

namespace LeetCode.Problems._8
{
	internal class Problem846
	{
		public bool IsNStraightHand(int[] hand, int groupSize)
		{
			if (hand.Length % groupSize != 0)
				return false;

			Array.Sort(hand);

			var cardCount = new Dictionary<int, int>();
			foreach (var card in hand)
				if (cardCount.ContainsKey(card))
					cardCount[card]++;
				else
					cardCount[card] = 1;

			foreach (var card in hand)
			{
				if (cardCount[card] == 0)
					continue;

				for (var i = 0; i < groupSize; i++)
				{
					var currentCard = card + i;
					if (!cardCount.ContainsKey(currentCard) || cardCount[currentCard] == 0)
						return false;
					cardCount[currentCard]--;
				}
			}

			return true;
		}
	}
}
