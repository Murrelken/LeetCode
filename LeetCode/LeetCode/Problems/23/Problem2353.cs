using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Problems._23
{
	internal class Problem2353
	{
		public class FoodRatings
		{
			private Dictionary<string, string> _cuisineByFood = new Dictionary<string, string>();
			private Dictionary<string, SortedList<int, List<string>>> _foodsByCuisine = new Dictionary<string, SortedList<int, List<string>>>();
			private Dictionary<string, int> _ratingByFood = new Dictionary<string, int>();

			public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
			{
				for (int i = 0; i < foods.Length; i++)
				{
					_cuisineByFood.Add(foods[i], cuisines[i]);
					_ratingByFood.Add(foods[i], ratings[i]);

					if (!_foodsByCuisine.TryAdd(cuisines[i], new SortedList<int, List<string>> (new DescComparer<int>()) { { ratings[i], new List<string> { foods[i] } } }))
						AddFoodWithRatingToSortedList(foods[i], cuisines[i], ratings[i]);
				}
			}

			private void AddFoodWithRatingToSortedList(string food, string cuisine, int rating)
			{
				if (!_foodsByCuisine[cuisine].ContainsKey(rating))
					_foodsByCuisine[cuisine].Add(rating, new List<string> { food });
				else
					_foodsByCuisine[cuisine][rating].Add(food);
			}

			public void ChangeRating(string food, int newRating)
			{
				var cuisine = _cuisineByFood[food];
				var currentRating = _ratingByFood[food];
				var sortedList = _foodsByCuisine[cuisine][currentRating];
				if (sortedList.Count == 1)
					_foodsByCuisine[cuisine].Remove(currentRating);
				else
					sortedList.Remove(food);
				AddFoodWithRatingToSortedList(food, cuisine, newRating);
				_ratingByFood[food] = newRating;
			}

			public string HighestRated(string cuisine) => _foodsByCuisine[cuisine].First().Value.Min();
		}
		class DescComparer<T> : IComparer<T>
		{
			public int Compare(T x, T y)
			{
				if (x == null) return -1;
				if (y == null) return 1;
				return Comparer<T>.Default.Compare(y, x);
			}
		}
	}
}
