using System.Linq;
using System.Text;

namespace LeetCode.Problems._28
{
	internal class Problem2864
	{
		public string MaximumOddBinaryNumber(string s)
		{
			var ones = s.Count(x => x == '1');
			var zeroes = s.Length - ones;
			var sb = new StringBuilder();
			while (ones > 1)
			{
				ones--;
				sb.Append("1");
			}
			while (zeroes > 0)
			{
				zeroes--;
				sb.Append("0");
			}
			sb.Append("1");
			return sb.ToString();
		}
	}
}
