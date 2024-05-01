namespace LeetCode.Problems._20
{
	internal class Problem2000
	{
		public string ReversePrefix(string word, char ch)
		{
			var index = word.IndexOf(ch);
			if (index == -1)
				return word;

			var chars = word.ToCharArray();
			var start = 0;
			var end = index;

			while (start < end)
			{
				var temp = chars[start];
				chars[start] = chars[end];
				chars[end] = temp;
				start++;
				end--;
			}

			return new string(chars);
		}
	}
}
