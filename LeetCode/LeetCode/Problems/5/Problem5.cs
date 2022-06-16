namespace LeetCode.Problems
{
    public class Problem5
    {
        public string LongestPalindrome(string s)
        {
            var result = string.Empty;

            for (var i = 0; i < s.Length; i++)
            {
                var odd = CheckOdd(i, s);
                if (odd.Length > result.Length)
                    result = odd;

                var even = CheckEven(i - 1, i, s);
                if (even.Length > result.Length)
                    result = even;
            }

            return result;
        }

        private string CheckOdd(int center, string s)
        {
            var result = $"{s[center]}";
            for (int i = 1; i <= s.Length / 2; i++)
            {
                if (center + i > s.Length - 1 || center - i < 0 || s[center - i] != s[center + i])
                    break;
                result = s.Substring(center - i, (center + i) - (center - i) + 1);
            }

            return result;
        }

        private string CheckEven(int left, int right, string s)
        {
            var result = string.Empty;
            while (left >= 0 && right <= s.Length - 1 && s[left] == s[right])
            {
                result = s.Substring(left, right - left + 1);
                left--;
                right++;
            }

            return result;
        }
    }
}