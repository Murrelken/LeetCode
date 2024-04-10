using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._9
{
	internal class Problem950
	{
		public int[] DeckRevealedIncreasing(int[] deck)
		{
			Array.Sort(deck);
			var indexQueue = new Queue<int>(Enumerable.Range(0, deck.Length));
			var result = new int[deck.Length];

			foreach (int card in deck)
			{
				result[indexQueue.Dequeue()] = card;
				if (indexQueue.Count > 0)
					indexQueue.Enqueue(indexQueue.Dequeue());
			}

			return result;
		}
	}
}
